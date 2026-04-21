using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSiteLibrary
{
        public class ProfileImage
        {
            private int imageID;
            private int memberID;
            private String imageURL;
            private bool isPrimary;
            private int displayOrder;
            private DateTime uploadedOn;

            public int ImageID
            {
                get { return imageID; }
                set { imageID = value; }
            }

            public int MemberID
            {
                get { return memberID; }
                set { memberID = value; }
            }

            public String ImageURL
            {
                get { return imageURL; }
                set { imageURL = value; }
            }

            public bool IsPrimary
            {
                get { return isPrimary; }
                set { isPrimary = value; }
            }

            public int DisplayOrder
            {
                get { return displayOrder; }
                set { displayOrder = value; }
            }

            public DateTime UploadedOn
            {
                get { return uploadedOn; }
                set { uploadedOn = value; }
            }
        }
    }