using Microsoft.AspNetCore.Mvc;
using Project3_DatingSite.Models;

namespace Project3_DatingSite.Controllers
{
    public class DatePlansController : Controller
    {
        public IActionResult Index()
        {
            int? memberId = HttpContext.Session.GetInt32("MemberID");

            if (memberId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<DatePlanViewModel> list = GetMockDatePlans();
            return View(list);
        }

        private List<DatePlanViewModel> GetMockDatePlans()
        {
            List<DatePlanViewModel> list = new List<DatePlanViewModel>();

            DatePlanViewModel one = new DatePlanViewModel();
            one.DatePlanID = 1;
            one.OtherPersonName = "Steph Curry";
            one.PlannedDateTimeText = "Saturday, April 20 at 7:00 PM";
            one.PlanDescription = "Dinner at a nice restaurant in Center City.";
            list.Add(one);

            DatePlanViewModel two = new DatePlanViewModel();
            two.DatePlanID = 2;
            two.OtherPersonName = "Diana Prince";
            one.PlannedDateTimeText = "Sunday, April 21 at 2:00 PM";
            two.PlanDescription = "Coffee and a walk through the park.";
            list.Add(two);

            return list;
        }
    }
}