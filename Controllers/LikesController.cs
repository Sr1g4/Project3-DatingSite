using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;

namespace Project3_DatingSite.Controllers
{
    public class LikesController : Controller
    {
        public IActionResult Sent()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<LikeViewModel> list = GetMockSentLikes();
            return View(list);
        }

        public IActionResult Received()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<LikeViewModel> list = GetMockReceivedLikes();
            return View(list);
        }

        private List<LikeViewModel> GetMockSentLikes()
        {
            List<LikeViewModel> list = new List<LikeViewModel>();

            LikeViewModel one = new LikeViewModel();
            one.MemberID = 4;
            one.FirstName = "Diana";
            one.LastName = "Prince";
            one.City = "Philadelphia";
            one.State = "PA";
            one.Occupation = "Consultant";
            one.PhotoURL = "https://i.imgur.com/tXQ9jQx.jpg";
            list.Add(one);

            LikeViewModel two = new LikeViewModel();
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

        private List<LikeViewModel> GetMockReceivedLikes()
        {
            List<LikeViewModel> list = new List<LikeViewModel>();

            LikeViewModel one = new LikeViewModel();
            one.MemberID = 1;
            one.FirstName = "Clark";
            one.LastName = "Kent";
            one.City = "Philadelphia";
            one.State = "PA";
            one.Occupation = "Journalist";
            one.PhotoURL = "https://i.imgur.com/8Km9tLL.jpg";
            list.Add(one);

            return list;
        }
    }
}