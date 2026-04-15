namespace Project3_DatingSite.Models
{
        public class ForgotPasswordViewModel
        {
            private int memberID;
            private string username;
            private int questionID;
            private string questionText;
            private string answer;
            private string newPassword;

            public int MemberID
            {
                get { return memberID; }
                set { memberID = value; }
            }

            public string Username
            {
                get { return username; }
                set { username = value; }
            }

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

            public string Answer
            {
                get { return answer; }
                set { answer = value; }
            }

            public string NewPassword
            {
                get { return newPassword; }
                set { newPassword = value; }
            }
        }
    }