namespace Project3_DatingSite.Models
{
    public class ProfileViewModel
    {
        private int memberID;
        private string firstName;
        private string lastName;
        private bool isProfilePublic;
        private string city;
        private string state;
        private string profileDescription;
        private string photoURL;
        private int age;
        private string occupation;
        private string commitmentType;
        private string email;
        private string phone;
        private string address;
        private string contactCity;
        private string contactState;
        private string zip;
        private int heightInches;
        private int weightLbs;

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public bool IsProfilePublic
        {
            get { return isProfilePublic; }
            set { isProfilePublic = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string ProfileDescription
        {
            get { return profileDescription; }
            set { profileDescription = value; }
        }

        public string PhotoURL
        {
            get { return photoURL; }
            set { photoURL = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string CommitmentType
        {
            get { return commitmentType; }
            set { commitmentType = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string ContactCity
        {
            get { return contactCity; }
            set { contactCity = value; }
        }

        public string ContactState
        {
            get { return contactState; }
            set { contactState = value; }
        }

        public string Zip
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