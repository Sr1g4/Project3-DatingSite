using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSiteLibrary
{
    public class DatePlan
    {
        private int datePlanID;
        private int dateRequestID;
        private DateTime plannedDateTime;
        private String planDescription;
        private int lastUpdatedByMemberID;
        private DateTime updatedOn;

        public int DatePlanID
        {
            get { return datePlanID; }
            set { datePlanID = value; }
        }

        public int DateRequestID
        {
            get { return dateRequestID; }
            set { dateRequestID = value; }
        }

        public DateTime PlannedDateTime
        {
            get { return plannedDateTime; }
            set { plannedDateTime = value; }
        }
        public String PlanDescription
        {
            get { return planDescription; }
            set { planDescription = value; }
        }

        public int LastUpdatedByMemberID
        {
            get { return lastUpdatedByMemberID; }
            set { lastUpdatedByMemberID = value; }
        }

        public DateTime UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }
    }
}