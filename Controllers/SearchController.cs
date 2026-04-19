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

            return View("Results", results);
        }

        private List<SearchResultViewModel> GetSearchResults(SearchViewModel model, int currentMemberID)
        {
            List<SearchResultViewModel> results = new List<SearchResultViewModel>();

            try
            {
                results = TrySearchApi(model, currentMemberID);

                if (results != null && results.Count > 0)
                {
                    return results;
                }
            }
            catch
            {
            }

            return GetMockSearchResults(model);
        }

        private List<SearchResultViewModel> TrySearchApi(SearchViewModel model, int currentMemberID)
        {
            List<SearchResultViewModel> results = new List<SearchResultViewModel>();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            string apiUrl = "";
            bool usedApi = false;

            if (model.Keyword != null && model.Keyword.Trim() != "")
            {
                apiUrl = "http://localhost:7295/api/SearchService/SearchByKeyword?keyword=" +
                         Uri.EscapeDataString(model.Keyword) +
                         "&currentMemberID=" + currentMemberID;
                response = client.GetAsync(apiUrl).Result;
                usedApi = true;
            }
            else if (model.City != null && model.City.Trim() != "" &&
                     model.State != null && model.State.Trim() != "")
            {
                apiUrl = "http://localhost:7295/api/SearchService/SearchByLocation?city=" +
                         Uri.EscapeDataString(model.City) +
                         "&state=" + Uri.EscapeDataString(model.State) +
                         "&currentMemberID=" + currentMemberID;
                response = client.GetAsync(apiUrl).Result;
                usedApi = true;
            }
            else if (model.MinAge > 0 && model.MaxAge > 0)
            {
                apiUrl = "http://localhost:7295/api/SearchService/SearchByAgeRange?minAge=" +
                         model.MinAge +
                         "&maxAge=" + model.MaxAge +
                         "&currentMemberID=" + currentMemberID;
                response = client.GetAsync(apiUrl).Result;
                usedApi = true;
            }
            else if (model.CommitmentType != null && model.CommitmentType.Trim() != "")
            {
                apiUrl = "http://localhost:7295/api/SearchService/SearchByCommitment?commitmentType=" +
                         Uri.EscapeDataString(model.CommitmentType) +
                         "&currentMemberID=" + currentMemberID;
                response = client.GetAsync(apiUrl).Result;
                usedApi = true;
            }

            if (usedApi == false)
            {
                apiUrl = "http://localhost:7295/api/SearchService/GetAll?currentMemberID=" + currentMemberID;
                response = client.GetAsync(apiUrl).Result;
            }

            if (response == null || response.IsSuccessStatusCode == false)
            {
                return new List<SearchResultViewModel>();
            }

            string json = response.Content.ReadAsStringAsync().Result;

            if (json == null || json.Trim() == "")
            {
                return new List<SearchResultViewModel>();
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

        private List<SearchResultViewModel> GetMockSearchResults(SearchViewModel model)
        {
            List<SearchResultViewModel> list = new List<SearchResultViewModel>();

            SearchResultViewModel one = new SearchResultViewModel();
            one.MemberID = 1;
            one.FirstName = "Clark";
            one.LastName = "Kent";
            one.City = "Philadelphia";
            one.State = "PA";
            one.Age = 28;
            one.Occupation = "Journalist";
            one.CommitmentType = "Long-Term";
            one.PhotoURL = "https://i.imgur.com/8Km9tLL.jpg";
            one.ProfileDescription = "Loyal, thoughtful, and looking for something real.";
            list.Add(one);

            SearchResultViewModel two = new SearchResultViewModel();
            two.MemberID = 4;
            two.FirstName = "Diana";
            two.LastName = "Prince";
            two.City = "Philadelphia";
            two.State = "PA";
            two.Age = 27;
            two.Occupation = "Consultant";
            two.CommitmentType = "Serious Dating";
            two.PhotoURL = "https://i.imgur.com/tXQ9jQx.jpg";
            two.ProfileDescription = "Confident, adventurous, and values honesty.";
            list.Add(two);

            SearchResultViewModel three = new SearchResultViewModel();
            three.MemberID = 10;
            three.FirstName = "Steph";
            three.LastName = "Curry";
            three.City = "San Francisco";
            three.State = "CA";
            three.Age = 30;
            three.Occupation = "Athlete";
            three.CommitmentType = "Dating";
            three.PhotoURL = "https://i.imgur.com/O3ZQZ7B.jpg";
            three.ProfileDescription = "Driven, family-oriented, and loves meaningful conversation.";
            list.Add(three);

            return FilterMockResults(list, model);
        }

        private List<SearchResultViewModel> FilterMockResults(List<SearchResultViewModel> list, SearchViewModel model)
        {
            List<SearchResultViewModel> filtered = new List<SearchResultViewModel>();

            for (int i = 0; i < list.Count; i++)
            {
                bool match = true;

                if (model.City != null && model.City.Trim() != "")
                {
                    if (list[i].City == null || list[i].City.ToLower().Contains(model.City.ToLower()) == false)
                    {
                        match = false;
                    }
                }

                if (model.State != null && model.State.Trim() != "")
                {
                    if (list[i].State == null || list[i].State.ToLower().Contains(model.State.ToLower()) == false)
                    {
                        match = false;
                    }
                }

                if (model.MinAge > 0)
                {
                    if (list[i].Age < model.MinAge)
                    {
                        match = false;
                    }
                }

                if (model.MaxAge > 0)
                {
                    if (list[i].Age > model.MaxAge)
                    {
                        match = false;
                    }
                }

                if (model.CommitmentType != null && model.CommitmentType.Trim() != "")
                {
                    if (list[i].CommitmentType == null || list[i].CommitmentType.ToLower().Contains(model.CommitmentType.ToLower()) == false)
                    {
                        match = false;
                    }
                }

                if (model.Keyword != null && model.Keyword.Trim() != "")
                {
                    string keyword = model.Keyword.ToLower();
                    string combinedText = "";

                    if (list[i].FirstName != null)
                    {
                        combinedText += list[i].FirstName.ToLower() + " ";
                    }

                    if (list[i].LastName != null)
                    {
                        combinedText += list[i].LastName.ToLower() + " ";
                    }

                    if (list[i].Occupation != null)
                    {
                        combinedText += list[i].Occupation.ToLower() + " ";
                    }

                    if (list[i].ProfileDescription != null)
                    {
                        combinedText += list[i].ProfileDescription.ToLower() + " ";
                    }

                    if (combinedText.Contains(keyword) == false)
                    {
                        match = false;
                    }
                }

                if (match == true)
                {
                    filtered.Add(list[i]);
                }
            }

            return filtered;
        }
    }
}