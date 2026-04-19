namespace Project3_DatingSite.Models
{
    public class SearchResultViewModel
    {
        private int memberID;
        private string firstName;
        private string lastName;
        private string city;
        private string state;
        private int age;
        private string occupation;
        private string commitmentType;
        private string photoURL;
        private string profileDescription;

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

        public string PhotoURL
        {
            get { return photoURL; }
            set { photoURL = value; }
        }

        public string ProfileDescription
        {
            get { return profileDescription; }
            set { profileDescription = value; }
        }
    }
}