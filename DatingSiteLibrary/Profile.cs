using System;

namespace DatingSiteLibrary
{
    public class Profile
    {
        private int memberID;
        private int age;
        private String firstName;
        private String lastName;
        private int heightInches;
        private int weightLbs;
        private String city;
        private String state;
        private String profileDescription;
        private String photoURL;
        private String occupation;
        private String commitmentType;
        private String email;
        private String phone;
        private String address;
        private String contactCity;
        private String contactState;
        private String zip;
        private bool isProfilePublic;


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

        public bool IsProfilePublic
        {
            get { return isProfilePublic; }
            set { isProfilePublic = value; }
        }

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public String ProfileDescription
        {
            get { return profileDescription; }
            set { profileDescription = value; }
        }

        public String PhotoURL
        {
            get { return photoURL; }
            set { photoURL = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public String Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public String CommitmentType
        {
            get { return commitmentType; }
            set { commitmentType = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String ContactCity
        {
            get { return contactCity; }
            set { contactCity = value; }
        }

        public String ContactState
        {
            get { return contactState; }
            set { contactState = value; }
        }

        public String Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public int HeightInches
        {
            get { return heightInches; }
            set { heightInches = value; }
        }

        public int WeightLbs
        {
            get { return weightLbs; }
            set { weightLbs = value; }
        }
    }
}