using System;

namespace DatingSiteLibrary
{
    public class ProfileItems
    {
        private int profileItemID;
        private int memberID;
        private String itemType;
        private String itemText;

        public int ProfileItemID
        {
            get { return profileItemID; }
            set { profileItemID = value; }
        }

        public int MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public String ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }

        public String ItemText
        {
            get { return itemText; }
            set { itemText = value; }
        }
    }
}