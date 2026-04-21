using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSiteLibrary
{
    public class DateRequest
    {
        private int dateRequestID;
        private int senderMemberID;
        private int receiverMemberID;
        private String status;
        private String message;
        private bool receiverViewed;
        private bool senderViewed;
        private DateTime createdOn;

        public int DateRequestID
        {
            get { return dateRequestID; }
            set { dateRequestID = value; }
        }

        public int SenderMemberID
        {
            get { return senderMemberID; }
            set { senderMemberID = value; }
        }

        public int ReceiverMemberID
        {
            get { return receiverMemberID; }
            set { receiverMemberID = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        public bool ReceiverViewed
        {
            get { return receiverViewed; }
            set { receiverViewed = value; }
        }

        public bool SenderViewed
        {
            get { return senderViewed; }
            set { senderViewed = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
    }
}