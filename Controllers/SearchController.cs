using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;
using System.Text.Json;

namespace Project3_DatingSite.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(new SearchViewModel());
        }

        [HttpPost]
        public IActionResult Index(SearchViewModel model)
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (model == null)
            {
                ViewData["Message"] = "Search could not be processed.";
                return View(new SearchViewModel());
            }

            List<SearchResultViewModel> results = GetSearchResults(model, memberId.Value);

            if (results == null || results.Count == 0)
            {
                ViewData["Message"] = "No profiles matched your search.";
            }

            return View("Results", results);
        }

        private List<SearchResultViewModel> GetSearchResults(SearchViewModel model, int currentMemberID)
        {
            List<SearchResultViewModel> results = new List<SearchResultViewModel>();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            string apiUrl = "";

            if (model.Keyword != null && model.Keyword.Trim() != "")
            {
                apiUrl = "http://localhost:5220/api/SearchService/SearchByKeyword?keyword=" +
                         Uri.EscapeDataString(model.Keyword) +
                         "&currentMemberID=" + currentMemberID;

                response = client.GetAsync(apiUrl).Result;
            }
            else if (model.City != null && model.City.Trim() != "" &&
                     model.State != null && model.State.Trim() != "")
            {
                apiUrl = "http://localhost:5220/api/SearchService/SearchByLocation?city=" +
                         Uri.EscapeDataString(model.City) +
                         "&state=" + Uri.EscapeDataString(model.State) +
                         "&currentMemberID=" + currentMemberID;

                response = client.GetAsync(apiUrl).Result;
            }
            else if (model.MinAge > 0 && model.MaxAge > 0)
            {
                apiUrl = "http://localhost:5220/api/SearchService/SearchByAgeRange?minAge=" +
                         model.MinAge +
                         "&maxAge=" + model.MaxAge +
                         "&currentMemberID=" + currentMemberID;

                response = client.GetAsync(apiUrl).Result;
            }
            else if (model.CommitmentType != null && model.CommitmentType.Trim() != "")
            {
                apiUrl = "http://localhost:5220/api/SearchService/SearchByCommitment?commitmentType=" +
                         Uri.EscapeDataString(model.CommitmentType) +
                         "&currentMemberID=" + currentMemberID;

                response = client.GetAsync(apiUrl).Result;
            }
            else
            {
                apiUrl = "http://localhost:5220/api/SearchService/GetAll?currentMemberID=" + currentMemberID;
                response = client.GetAsync(apiUrl).Result;
            }

            if (response == null)
            {
                return results;
            }

            if (response.IsSuccessStatusCode == false)
            {
                return results;
            }

            string json = response.Content.ReadAsStringAsync().Result;

            if (json == null || json.Trim() == "")
            {
                return results;
            }

            results = JsonSerializer.Deserialize<List<SearchResultViewModel>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (results == null)
            {
                results = new List<SearchResultViewModel>();
            }

            return results;
        }
    }
}