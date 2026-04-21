using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSiteLibrary
{
    public class SecurityQuestion
    {
        private int questionID;
        private string questionText;

        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
    }
}