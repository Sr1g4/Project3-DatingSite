namespace Project3_DatingSite.Models
{
    public class SearchViewModel
    {
        private string city;
        private string state;
        private int minAge;
        private int maxAge;
        private string commitmentType;
        private string keyword;

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

        public int MinAge
        {
            get { return minAge; }
            set { minAge = value; }
        }

        public int MaxAge
        {
            get { return maxAge; }
            set { maxAge = value; }
        }

        public string CommitmentType
        {
            get { return commitmentType; }
            set { commitmentType = value; }
        }

        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
    }
}