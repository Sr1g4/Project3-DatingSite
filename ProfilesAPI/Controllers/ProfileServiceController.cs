using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using DatingSiteLibrary;

namespace DatingProfilesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ProfilesService")]
    [ApiController]

    public class ProfilesServiceController : ControllerBase
    {
        [HttpGet("GetProfileByMemberID/{memberId}")]
        public Profile GetProfileByMemberID(int memberId)
        {
            Profile prof = null;

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_GetDisplayByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberId);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                prof = new Profile();

                prof.MemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"]);
                prof.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                prof.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                prof.City = ds.Tables[0].Rows[0]["City"].ToString();
                prof.State = ds.Tables[0].Rows[0]["State"].ToString();
                prof.ProfileDescription = ds.Tables[0].Rows[0]["ProfileDescription"].ToString();
                prof.PhotoURL = ds.Tables[0].Rows[0]["PhotoURL"].ToString();

                if (ds.Tables[0].Rows[0]["Age"] == DBNull.Value)
                    prof.Age = 0;
                else
                    prof.Age = Convert.ToInt32(ds.Tables[0].Rows[0]["Age"]);

                prof.Occupation = ds.Tables[0].Rows[0]["Occupation"].ToString();
                prof.CommitmentType = ds.Tables[0].Rows[0]["CommitmentType"].ToString();
                prof.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                prof.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                prof.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                prof.ContactCity = ds.Tables[0].Rows[0]["ContactCity"].ToString();
                prof.ContactState = ds.Tables[0].Rows[0]["ContactState"].ToString();
                prof.Zip = ds.Tables[0].Rows[0]["Zip"].ToString();

                if (ds.Tables[0].Rows[0]["HeightInches"] == DBNull.Value)
                    prof.HeightInches = 0;
                else
                    prof.HeightInches = Convert.ToInt32(ds.Tables[0].Rows[0]["HeightInches"]);

                if (ds.Tables[0].Rows[0]["WeightLbs"] == DBNull.Value)
                    prof.WeightLbs = 0;
                else
                    prof.WeightLbs = Convert.ToInt32(ds.Tables[0].Rows[0]["WeightLbs"]);

                prof.IsProfilePublic = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsProfilePublic"]);
            }

                return prof;
            
        }

        [HttpPost("AddProfile")]
        public bool AddProfile([FromBody] Profile prof)
        {
            if (prof == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_Insert";

            cmd.Parameters.AddWithValue("@theMemberID", prof.MemberID);
            cmd.Parameters.AddWithValue("@theCity", prof.City);
            cmd.Parameters.AddWithValue("@theState", prof.State);
            cmd.Parameters.AddWithValue("@theProfileDescription", prof.ProfileDescription);
            cmd.Parameters.AddWithValue("@thePhotoURL", prof.PhotoURL);
            cmd.Parameters.AddWithValue("@theAge", prof.Age);
            cmd.Parameters.AddWithValue("@theOccupation", prof.Occupation);
            cmd.Parameters.AddWithValue("@theCommitmentType", prof.CommitmentType);
            cmd.Parameters.AddWithValue("@theEmail", prof.Email);
            cmd.Parameters.AddWithValue("@thePhone", prof.Phone);
            cmd.Parameters.AddWithValue("@theAddress", prof.Address);
            cmd.Parameters.AddWithValue("@theContactCity", prof.ContactCity);
            cmd.Parameters.AddWithValue("@theContactState", prof.ContactState);
            cmd.Parameters.AddWithValue("@theZip", prof.Zip);
            cmd.Parameters.AddWithValue("@theHeightInches", prof.HeightInches);
            cmd.Parameters.AddWithValue("@theWeightLbs", prof.WeightLbs);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }

        [HttpPut("UpdateProfile")]
        public bool UpdateProfile([FromBody] Profile prof)
        {
            if (prof == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_Update";
            cmd.Parameters.AddWithValue("@theFirstName", prof.FirstName);
            cmd.Parameters.AddWithValue("@theLastName", prof.LastName);
            cmd.Parameters.AddWithValue("@theMemberID", prof.MemberID);
            cmd.Parameters.AddWithValue("@theCity", prof.City);
            cmd.Parameters.AddWithValue("@theState", prof.State);
            cmd.Parameters.AddWithValue("@theProfileDescription", prof.ProfileDescription);
            cmd.Parameters.AddWithValue("@thePhotoURL", prof.PhotoURL);
            cmd.Parameters.AddWithValue("@theAge", prof.Age);
            cmd.Parameters.AddWithValue("@theOccupation", prof.Occupation);
            cmd.Parameters.AddWithValue("@theCommitmentType", prof.CommitmentType);
            cmd.Parameters.AddWithValue("@theEmail", prof.Email);
            cmd.Parameters.AddWithValue("@thePhone", prof.Phone);
            cmd.Parameters.AddWithValue("@theAddress", prof.Address);
            cmd.Parameters.AddWithValue("@theContactCity", prof.ContactCity);
            cmd.Parameters.AddWithValue("@theContactState", prof.ContactState);
            cmd.Parameters.AddWithValue("@theZip", prof.Zip);
            cmd.Parameters.AddWithValue("@theHeightInches", prof.HeightInches);
            cmd.Parameters.AddWithValue("@theWeightLbs", prof.WeightLbs);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }

        [HttpDelete("DeleteProfile/{memberId}")]
        public bool DeleteProfile(int memberId)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Profile_Delete";
            cmd.Parameters.AddWithValue("@theMemberID", memberId);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }
    }
}