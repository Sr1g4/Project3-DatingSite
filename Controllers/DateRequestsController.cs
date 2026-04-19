using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;

namespace Project3_DatingSite.Controllers
{
    public class DateRequestsController : Controller
    {
        public IActionResult Index()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<DateRequestViewModel> list = GetMockDateRequests();
            return View(list);
        }

        private List<DateRequestViewModel> GetMockDateRequests()
        {
            List<DateRequestViewModel> list = new List<DateRequestViewModel>();

            DateRequestViewModel one = new DateRequestViewModel();
            one.DateRequestID = 1;
            one.OtherPersonName = "Diana Prince";
            one.Message = "Would you like to grab dinner this weekend?";
            one.Status = "Pending";
            one.Direction = "Sent";
            list.Add(one);

            DateRequestViewModel two = new DateRequestViewModel();
            two.DateRequestID = 2;
            two.OtherPersonName = "Steph Curry";
            two.Message = "Coffee date sometime this week?";
            two.Status = "Accepted";
            two.Direction = "Received";
            list.Add(two);

            return list;
        }
    }
}