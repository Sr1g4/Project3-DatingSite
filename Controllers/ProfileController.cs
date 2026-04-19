using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;
using DatingSiteLibrary;
using System.Text;
using System.Text.Json;

namespace Project3_DatingSite.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult CreateProfile()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ProfileViewModel model = new ProfileViewModel();
            model.MemberID = memberId.Value;
            model.FirstName = HttpContext.Session.GetString("FirstName");
            model.LastName = HttpContext.Session.GetString("LastName");

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateProfile(ProfileViewModel model)
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (model == null)
            {
                ViewData["Message"] = "Error occurred. Try again later.";
                return View(new ProfileViewModel());
            }

            model.MemberID = memberId.Value;
            model.FirstName = HttpContext.Session.GetString("FirstName");
            model.LastName = HttpContext.Session.GetString("LastName");

            Profile profToSend = new Profile();
            profToSend.MemberID = model.MemberID;
            profToSend.FirstName = model.FirstName;
            profToSend.LastName = model.LastName;
            profToSend.City = model.City;
            profToSend.State = model.State;
            profToSend.ProfileDescription = model.ProfileDescription;
            profToSend.PhotoURL = model.PhotoURL;
            profToSend.Age = model.Age;
            profToSend.Occupation = model.Occupation;
            profToSend.CommitmentType = model.CommitmentType;
            profToSend.Email = model.Email;
            profToSend.Phone = model.Phone;
            profToSend.Address = model.Address;
            profToSend.ContactCity = model.ContactCity;
            profToSend.ContactState = model.ContactState;
            profToSend.Zip = model.Zip;
            profToSend.HeightInches = model.HeightInches;
            profToSend.WeightLbs = model.WeightLbs;
            profToSend.IsProfilePublic = model.IsProfilePublic;

            string apiUrl = "http://localhost:7295/api/ProfilesService/AddProfile";

            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonSerializer.Serialize(profToSend),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

            if (response.IsSuccessStatusCode == false)
            {
                ViewData["Message"] = "Profile service failed.";
                return View(model);
            }

            string json = response.Content.ReadAsStringAsync().Result;
            bool success = JsonSerializer.Deserialize<bool>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (success == false)
            {
                ViewData["Message"] = "Profile could not be created.";
                return View(model);
            }

            return RedirectToAction("ViewProfile");
        }

        public IActionResult ViewProfile()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string apiUrl = "http://localhost:7295/api/ProfilesService/GetProfileByMemberID/" + memberId.Value;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode == false)
            {
                ViewData["Message"] = "Profile could not be loaded.";
                return View(new ProfileViewModel());
            }

            string json = response.Content.ReadAsStringAsync().Result;

            if (json == null || json.Trim() == "")
            {
                return RedirectToAction("CreateProfile");
            }

            Profile prof = JsonSerializer.Deserialize<Profile>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (prof == null || prof.MemberID <= 0)
            {
                return RedirectToAction("CreateProfile");
            }

            ProfileViewModel model = new ProfileViewModel();
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

        public IActionResult EditProfile()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string apiUrl = "http://localhost:7295/api/ProfilesService/GetProfileByMemberID/" + memberId.Value;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode == false)
            {
                ViewData["Message"] = "Profile could not be loaded.";
                return View(new ProfileViewModel());
            }

            string json = response.Content.ReadAsStringAsync().Result;

            Profile prof = JsonSerializer.Deserialize<Profile>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (prof == null || prof.MemberID <= 0)
            {
                return RedirectToAction("CreateProfile");
            }

            ProfileViewModel model = new ProfileViewModel();
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

        [HttpPost]
        public IActionResult EditProfile(ProfileViewModel model)
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (model == null)
            {
                ViewData["Message"] = "Error occurred. Try again later.";
                return View(new ProfileViewModel());
            }

            model.MemberID = memberId.Value;

            Profile profToSend = new Profile();
            profToSend.MemberID = model.MemberID;
            profToSend.FirstName = model.FirstName;
            profToSend.LastName = model.LastName;
            profToSend.City = model.City;
            profToSend.State = model.State;
            profToSend.ProfileDescription = model.ProfileDescription;
            profToSend.PhotoURL = model.PhotoURL;
            profToSend.Age = model.Age;
            profToSend.Occupation = model.Occupation;
            profToSend.CommitmentType = model.CommitmentType;
            profToSend.Email = model.Email;
            profToSend.Phone = model.Phone;
            profToSend.Address = model.Address;
            profToSend.ContactCity = model.ContactCity;
            profToSend.ContactState = model.ContactState;
            profToSend.Zip = model.Zip;
            profToSend.HeightInches = model.HeightInches;
            profToSend.WeightLbs = model.WeightLbs;
            profToSend.IsProfilePublic = model.IsProfilePublic;

            string apiUrl = "http://localhost:7295/api/ProfilesService/UpdateProfile";

            HttpClient client = new HttpClient();

            StringContent content = new StringContent(
                JsonSerializer.Serialize(profToSend),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response = client.PutAsync(apiUrl, content).Result;

            if (response.IsSuccessStatusCode == false)
            {
                ViewData["Message"] = "Profile update failed.";
                return View(model);
            }

            string json = response.Content.ReadAsStringAsync().Result;
            bool success = JsonSerializer.Deserialize<bool>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (success == false)
            {
                ViewData["Message"] = "Profile update failed.";
                return View(model);
            }

            HttpContext.Session.SetString("FirstName", model.FirstName);
            HttpContext.Session.SetString("LastName", model.LastName);

            return RedirectToAction("ViewProfile");
        }
    }
}