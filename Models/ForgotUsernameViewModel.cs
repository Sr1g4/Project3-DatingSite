namespace Project3_DatingSite.Models
{ 
        public class ForgotUsernameViewModel
        {
            private string email;
            private string recoveredUsername;

            public string Email
            {
                get { return email; }
                set { email = value; }
            }

            public string RecoveredUsername
            {
                get { return recoveredUsername; }
                set { recoveredUsername = value; }
            }
        }
    }