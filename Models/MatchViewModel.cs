namespace Project3_DatingSite.Models
{
    public class MatchViewModel
    {
        private int memberID;
        private string firstName;
        private string lastName;
        private string photoURL;
        private string city;
        private string state;
        private string occupation;

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

        public string PhotoURL
        {
            get { return photoURL; }
            set { photoURL = value; }
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

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }
    }
}