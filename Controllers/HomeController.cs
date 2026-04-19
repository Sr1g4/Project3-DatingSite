using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DatingSiteLibrary;

namespace Project3_DatingSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            bool hasProfile = false;
            string photoUrl = "";

            string apiUrl = "http://localhost:7295/api/ProfilesService/GetProfileByMemberID/" + memberId.Value;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                if (json != null && json.Trim() != "")
                {
                    Profile prof = JsonSerializer.Deserialize<Profile>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (prof != null && prof.MemberID > 0)
                    {
                        hasProfile = true;

                        if (prof.PhotoURL != null)
                        {
                            photoUrl = prof.PhotoURL;
                        }
                    }
                }
            }

            ViewData["HasProfile"] = hasProfile;
            ViewData["PhotoURL"] = photoUrl;

            return View();
        }
    }
}