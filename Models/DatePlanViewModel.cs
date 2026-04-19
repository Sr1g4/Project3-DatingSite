namespace Project3_DatingSite.Models
{
    public class DatePlanViewModel
    {
        private int datePlanID;
        private string otherPersonName;
        private string plannedDateTimeText;
        private string planDescription;

        public int DatePlanID
        {
            get { return datePlanID; }
            set { datePlanID = value; }
        }

        public string OtherPersonName
        {
            get { return otherPersonName; }
            set { otherPersonName = value; }
        }

        public string PlannedDateTimeText
        {
            get { return plannedDateTimeText; }
            set { plannedDateTimeText = value; }
        }

        public string PlanDescription
        {
            get { return planDescription; }
            set { planDescription = value; }
        }
    }
}