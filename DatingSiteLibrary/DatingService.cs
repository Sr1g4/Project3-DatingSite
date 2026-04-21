using System;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DatingSiteLibrary
{
    public class DatingService
    {
        private DBConnect objDB;

        public DatingService()
        {
            objDB = new DBConnect();
        }
        public DataSet GetMemberProfile(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_GetDisplayByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }

        public DataSet GetMembersByLocation(String city, String state, int currentMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Search_ByLocation";
            cmd.Parameters.AddWithValue("@theCity", city);
            cmd.Parameters.AddWithValue("@theState", state);
            cmd.Parameters.AddWithValue("@theCurrentMemberID", currentMemberID);
            return objDB.GetDataSet(cmd);
        }

        public DataSet GetAllMembers(int currentMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Search_GetAll";
            cmd.Parameters.AddWithValue("@theCurrentMemberID", currentMemberID);
            return objDB.GetDataSet(cmd);
        }

        public DataSet GetMembersByAgeRange(int minAge, int maxAge, int currentMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Search_ByAgeRange";
            cmd.Parameters.AddWithValue("@theMinAge", minAge);
            cmd.Parameters.AddWithValue("@theMaxAge", maxAge);
            cmd.Parameters.AddWithValue("@theCurrentMemberID", currentMemberID);
            return objDB.GetDataSet(cmd);
        }

        public DataSet GetMembersByCommitment(String commitment, int currentMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Search_ByCommitment";
            cmd.Parameters.AddWithValue("@theCommitmentType", commitment);
            cmd.Parameters.AddWithValue("@theCurrentMemberID", currentMemberID);
            return objDB.GetDataSet(cmd);
        }

        public DataSet GetMembersByKeyword(String keyword, int currentMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Search_ByKeyword";
            cmd.Parameters.AddWithValue("@theKeyword", keyword);
            cmd.Parameters.AddWithValue("@theCurrentMemberID", currentMemberID);
            return objDB.GetDataSet(cmd);
        }


        public int GetLikeCount(int likerMemberID, int likedMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Like_Exists";
            cmd.Parameters.AddWithValue("@theLikerMemberID", likerMemberID);
            cmd.Parameters.AddWithValue("@theLikedMemberID", likedMemberID);
            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return 1;
        }

        public DataSet GetLikedList(int likerID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Likes_GetSentByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", likerID);
            return objDB.GetDataSet(cmd);
        }


        public int SetProfileVisibility(int memberID, bool isProfilePublic)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_SetVisibility";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            cmd.Parameters.AddWithValue("@theIsProfilePublic", isProfilePublic);

            return objDB.DoUpdate(cmd);
        }

        public int AddLike(int likerID, int likedID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Like_Add";
            cmd.Parameters.AddWithValue("@theLikerMemberID", likerID);
            cmd.Parameters.AddWithValue("@theLikedMemberID", likedID);

            return objDB.DoUpdate(cmd);
        }

        public int DeleteLike(int likerID, int likedID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Like_Delete";
            cmd.Parameters.AddWithValue("@theLikerMemberID", likerID);
            cmd.Parameters.AddWithValue("@theLikedMemberID", likedID);

            return objDB.DoUpdate(cmd);
        }

        public DataSet GetLikesReceivedByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Likes_GetReceivedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }

        public int AddMatch(int member1ID, int member2ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Match_Add";
            cmd.Parameters.AddWithValue("@theMember1ID", member1ID);
            cmd.Parameters.AddWithValue("@theMember2ID", member2ID);

            return objDB.DoUpdate(cmd);
        }

        public int DeleteMatch(int member1ID, int member2ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Match_Delete";
            cmd.Parameters.AddWithValue("@theMember1ID", member1ID);
            cmd.Parameters.AddWithValue("@theMember2ID", member2ID);

            return objDB.DoUpdate(cmd);
        }

        public DataSet GetMatchesByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Matches_GetByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }
        public int Login(String username, String password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_Login";
            cmd.Parameters.AddWithValue("@theUsername", username);
            cmd.Parameters.AddWithValue("@thePassword", password);

            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"].ToString());
        }

        public int Register(String username, String password, String firstName, String lastName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_Register";
            cmd.Parameters.AddWithValue("@theUsername", username);
            cmd.Parameters.AddWithValue("@thePassword", password);
            cmd.Parameters.AddWithValue("@theFirstName", firstName);
            cmd.Parameters.AddWithValue("@theLastName", lastName);


            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"].ToString());
        }
        public DataSet GetMemberByID(int memberID)
        { 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_GetByID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }

        public DataSet GetAccountByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_GetByID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }

        public int InsertProfile(int memberID, String city, String state, String profileDescription, String photoURL, int age, String occupation, String commitmentType, String email, String phone, String address, String contactCity, String contactState, String zip, int heightInches, int weightLbs)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_Insert";

            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            cmd.Parameters.AddWithValue("@theCity", city);
            cmd.Parameters.AddWithValue("@theState", state);
            cmd.Parameters.AddWithValue("@theProfileDescription", profileDescription);
            cmd.Parameters.AddWithValue("@thePhotoURL", photoURL);
            cmd.Parameters.AddWithValue("@theAge", age);
            cmd.Parameters.AddWithValue("@theOccupation", occupation);
            cmd.Parameters.AddWithValue("@theCommitmentType", commitmentType);
            cmd.Parameters.AddWithValue("@theEmail", email);
            cmd.Parameters.AddWithValue("@thePhone", phone);
            cmd.Parameters.AddWithValue("@theAddress", address);
            cmd.Parameters.AddWithValue("@theContactCity", contactCity);
            cmd.Parameters.AddWithValue("@theContactState", contactState);
            cmd.Parameters.AddWithValue("@theZip", zip);
            cmd.Parameters.AddWithValue("@theHeightInches", heightInches);
            cmd.Parameters.AddWithValue("@theWeightLbs", weightLbs);
            return objDB.DoUpdate(cmd);
        }

        public int UpdateProfile(int memberID, String city, String state, String profileDescription, String photoURL, int age, String occupation, String commitmentType, String email, String phone, String address, String contactCity, String contactState, String zip, int heightInches, int weightLbs)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_Update";

            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            cmd.Parameters.AddWithValue("@theCity", city);
            cmd.Parameters.AddWithValue("@theState", state);
            cmd.Parameters.AddWithValue("@theProfileDescription", profileDescription);
            cmd.Parameters.AddWithValue("@thePhotoURL", photoURL);
            cmd.Parameters.AddWithValue("@theAge", age);
            cmd.Parameters.AddWithValue("@theOccupation", occupation);
            cmd.Parameters.AddWithValue("@theCommitmentType", commitmentType);
            cmd.Parameters.AddWithValue("@theEmail", email);
            cmd.Parameters.AddWithValue("@thePhone", phone);
            cmd.Parameters.AddWithValue("@theAddress", address);
            cmd.Parameters.AddWithValue("@theContactCity", contactCity);
            cmd.Parameters.AddWithValue("@theContactState", contactState);
            cmd.Parameters.AddWithValue("@theZip", zip);
            cmd.Parameters.AddWithValue("@theHeightInches", heightInches);
            cmd.Parameters.AddWithValue("@theWeightLbs", weightLbs);

            return objDB.DoUpdate(cmd);
        }

        public DataSet GetProfileByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_GetByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }


        public int AddProfileItem(int memberID, String itemType, String itemText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ProfileItem_Add";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            cmd.Parameters.AddWithValue("@theItemType", itemType);
            cmd.Parameters.AddWithValue("@theItemText", itemText);
            return objDB.DoUpdate(cmd);
        }

        public int DeleteProfileItemsByType(int memberID, String itemType)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ProfileItems_DeleteByType";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            cmd.Parameters.AddWithValue("@theItemType", itemType);
            return objDB.DoUpdate(cmd);
        }

        public DataSet GetProfileItemsByType(int memberID, String itemType)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ProfileItems_GetByType";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            cmd.Parameters.AddWithValue("@theItemType", itemType);
            return objDB.GetDataSet(cmd);
        }

        public int AddDateRequest(int senderMemberID, int receiverMemberID, String message)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequest_Add";
            cmd.Parameters.AddWithValue("@theSenderMemberID", senderMemberID);
            cmd.Parameters.AddWithValue("@theReceiverMemberID", receiverMemberID);
            cmd.Parameters.AddWithValue("@theMessage", message);
            return objDB.DoUpdate(cmd);
        }

        public DataSet GetDateRequestByID(int dateRequestID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequest_GetByID";
            cmd.Parameters.AddWithValue("@theDateRequestID", dateRequestID);
            return objDB.GetDataSet(cmd);
        }

        public DataSet GetDateRequests_GetSentByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequests_GetSentByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            return objDB.GetDataSet(cmd);
        }

        public DataSet GetDateRequests_GetReceivedByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequests_GetReceivedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            return objDB.GetDataSet(cmd);
        }

        public int SetDateRequestStatus(int dateRequestID, String status)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequest_SetStatus";
            cmd.Parameters.AddWithValue("@theDateRequestID", dateRequestID);
            cmd.Parameters.AddWithValue("@theStatus", status);
            return objDB.DoUpdate(cmd);
        }

        public int HasAcceptedBetweenMembers(int member1ID, int member2ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequest_HasAcceptedBetweenMembers";
            cmd.Parameters.AddWithValue("@theMember1ID", member1ID);
            cmd.Parameters.AddWithValue("@theMember2ID", member2ID);
            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return 1;
        }

        public int InsertDatePlan(int dateRequestID, DateTime plannedDateTime, String planDescription, int lastUpdatedByMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DatePlan_Insert";
            cmd.Parameters.AddWithValue("@theDateRequestID", dateRequestID);
            cmd.Parameters.AddWithValue("@thePlannedDateTime", plannedDateTime);
            cmd.Parameters.AddWithValue("@thePlanDescription", planDescription);
            cmd.Parameters.AddWithValue("@theLastUpdatedByMemberID", lastUpdatedByMemberID);
            return objDB.DoUpdate(cmd);
        }

        public int UpdateDatePlan(int datePlanID, DateTime plannedDateTime, String planDescription, int lastUpdatedByMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DatePlan_Update";
            cmd.Parameters.AddWithValue("@theDatePlanID", datePlanID);
            cmd.Parameters.AddWithValue("@thePlannedDateTime", plannedDateTime);
            cmd.Parameters.AddWithValue("@thePlanDescription", planDescription);
            cmd.Parameters.AddWithValue("@theLastUpdatedByMemberID", lastUpdatedByMemberID);
            return objDB.DoUpdate(cmd);
        }

        public DataSet GetDatePlansByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DatePlans_GetByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.GetDataSet(cmd);
        }
        public int GetLikesReceivedCountByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Likes_GetCountReceivedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["TotalLikes"].ToString());
        }
        public int GetProfileViewCountByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ProfileViews_GetCountByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["TotalViews"].ToString());
        }

        public int GetNewMatchCountByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Matches_GetNewCountByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["NewMatchCount"].ToString());
        }

        public int SetMatchesViewedByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Matches_SetViewedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);

            return objDB.DoUpdate(cmd);
        }
        public int GetNewDateRequestCountByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequests_GetNewCountByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["NewRequestCount"].ToString());
        }

        public int SetReceivedDateRequestsViewedByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DateRequests_SetReceivedViewedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            return objDB.DoUpdate(cmd);
        }

        public DataSet GetDatePlanByDateRequestID(int dateRequestID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_DatePlan_GetByDateRequestID";
            cmd.Parameters.AddWithValue("@theDateRequestID", dateRequestID);
            return objDB.GetDataSet(cmd);
        }
        public int AddProfileView(int viewerMemberID, int viewedMemberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ProfileView_Add";
            cmd.Parameters.AddWithValue("@theViewerMemberID", viewerMemberID);
            cmd.Parameters.AddWithValue("@theViewedMemberID", viewedMemberID);
            return objDB.DoUpdate(cmd);
        }
        public DataSet GetProfileViewsByViewedMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ProfileViews_GetByViewedMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            return objDB.GetDataSet(cmd);
        }
        public int GetNewLikeCountReceivedByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Likes_GetNewCountReceivedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            DataSet ds = objDB.GetDataSet(cmd);

            if (ds == null)
                return 0;
            if (ds.Tables.Count == 0)
                return 0;
            if (ds.Tables[0].Rows.Count == 0)
                return 0;

            return Convert.ToInt32(ds.Tables[0].Rows[0]["NewLikeCount"].ToString());
        }

        public int SetReceivedLikesViewedByMemberID(int memberID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Likes_SetReceivedViewedByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberID);
            return objDB.DoUpdate(cmd);
        }
    }

}