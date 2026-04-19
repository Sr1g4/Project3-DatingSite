namespace Project3_DatingSite.Models
{
    public class DateRequestViewModel
    {
        private int dateRequestID;
        private string otherPersonName;
        private string message;
        private string status;
        private string direction;

        public int DateRequestID
        {
            get { return dateRequestID; }
            set { dateRequestID = value; }
        }

        public string OtherPersonName
        {
            get { return otherPersonName; }
            set { otherPersonName = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}