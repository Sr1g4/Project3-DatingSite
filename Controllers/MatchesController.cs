using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;

namespace Project3_DatingSite.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<MatchViewModel> list = GetMockMatches();
            return View(list);
        }

        private List<MatchViewModel> GetMockMatches()
        {
            List<MatchViewModel> list = new List<MatchViewModel>();

            MatchViewModel one = new MatchViewModel();
            one.MemberID = 4;
            one.FirstName = "Diana";
            one.LastName = "Prince";
            one.City = "Philadelphia";
            one.State = "PA";
            one.Occupation = "Consultant";
            one.PhotoURL = "https://i.imgur.com/tXQ9jQx.jpg";
            list.Add(one);

            MatchViewModel two = new MatchViewModel();
            two.MemberID = 10;
            two.FirstName = "Steph";
            two.LastName = "Curry";
            two.City = "San Francisco";
            two.State = "CA";
            two.Occupation = "Athlete";
            two.PhotoURL = "https://i.imgur.com/O3ZQZ7B.jpg";
            list.Add(two);

            return list;
        }
    }
}