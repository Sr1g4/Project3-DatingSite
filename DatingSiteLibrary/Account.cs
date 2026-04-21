using System;

namespace DatingSiteLibrary
{
    public class Account
    {
        private int memberID;
        private String username;
        private String password;
        private String firstName;
        private String lastName;
        private String email;
        private bool isAccountActive;
        private DateTime createdOn;
        private bool isEmailVerified;
        private String verificationCode;
        private DateTime verificationCodeExpiresOn;
        private String resetCode;
        private DateTime resetCodeExpiresOn;

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public bool IsAccountActive
        {
            get { return isAccountActive; }
            set { isAccountActive = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        public bool IsEmailVerified
        {
            get { return isEmailVerified; }
            set { isEmailVerified = value; }
        }

        public String VerificationCode
        {
            get { return verificationCode; }
            set { verificationCode = value; }
        }

        public DateTime VerificationCodeExpiresOn
        {
            get { return verificationCodeExpiresOn; }
            set { verificationCodeExpiresOn = value; }
        }

        public String ResetCode
        {
            get { return resetCode; }
            set { resetCode = value; }
        }

        public DateTime ResetCodeExpiresOn
        {
            get { return resetCodeExpiresOn; }
            set { resetCodeExpiresOn = value; }
        }
    }
}