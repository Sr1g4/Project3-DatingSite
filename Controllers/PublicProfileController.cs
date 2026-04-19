using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;
using DatingSiteLibrary;
using System.Text.Json;

namespace Project3_DatingSite.Controllers
{
    public class PublicProfileController : Controller
    {
        public IActionResult Details(int memberId)
        {
            int? currentMemberId = HttpContext.Session.GetInt32("MemberID");

            if (currentMemberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string apiUrl = "http://localhost:7295/api/ProfilesService/GetProfileByMemberID/" + memberId;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode == false)
            {
                ViewData["Message"] = "Profile could not be loaded.";
                return View(new PublicProfileViewModel());
            }

            string json = response.Content.ReadAsStringAsync().Result;

            if (json == null || json.Trim() == "")
            {
                ViewData["Message"] = "Profile could not be loaded.";
                return View(new PublicProfileViewModel());
            }

            Profile prof = JsonSerializer.Deserialize<Profile>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (prof == null || prof.MemberID <= 0)
            {
                ViewData["Message"] = "Profile could not be loaded.";
                return View(new PublicProfileViewModel());
            }

            PublicProfileViewModel model = new PublicProfileViewModel();
            model.MemberID = prof.MemberID;
            model.FirstName = prof.FirstName;
            model.LastName = prof.LastName;
            model.City = prof.City;
            model.State = prof.State;
            model.ProfileDescription = prof.ProfileDescription;
            model.PhotoURL = prof.PhotoURL;
            model.Age = prof.Age;
            model.Occupation = prof.Occupation;
            model.CommitmentType = prof.CommitmentType;
            model.Email = prof.Email;
            model.Phone = prof.Phone;
            model.Address = prof.Address;
            model.ContactCity = prof.ContactCity;
            model.ContactState = prof.ContactState;
            model.Zip = prof.Zip;
            model.HeightInches = prof.HeightInches;
            model.WeightLbs = prof.WeightLbs;
            model.IsProfilePublic = prof.IsProfilePublic;

            return View(model);
        }
    }
}