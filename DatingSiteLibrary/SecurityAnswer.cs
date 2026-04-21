using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSiteLibrary
{
    public class SecurityAnswer
    {
        private int memberID;
        private int questionID;
        private string answer;

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}