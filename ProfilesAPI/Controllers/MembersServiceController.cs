using Microsoft.AspNetCore.Mvc;
using DatingSiteLibrary;
using Utilities;
using System.Data.SqlClient;
using System.Data;
namespace DatingProfilesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/MembersService")]
    [ApiController]
    public class MembersServiceController : ControllerBase
    {
        [HttpPost("Login")]
        public Account Login([FromBody] Account acct)
        {
            Account acctFound = null;

            if (acct == null)
            {
                return null;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_Login";
            cmd.Parameters.AddWithValue("@theUsername", acct.Username);
            cmd.Parameters.AddWithValue("@thePassword", acct.Password);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                acctFound = new Account();

                acctFound.MemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"]);
                acctFound.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                acctFound.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                acctFound.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                acctFound.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                acctFound.IsAccountActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAccountActive"]);
                acctFound.CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
                acctFound.IsEmailVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsEmailVerified"]);
                acctFound.VerificationCode = ds.Tables[0].Rows[0]["VerificationCode"].ToString();

                if (ds.Tables[0].Rows[0]["VerificationCodeExpiresOn"] == DBNull.Value)
                    acctFound.VerificationCodeExpiresOn = DateTime.MinValue;
                else
                    acctFound.VerificationCodeExpiresOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["VerificationCodeExpiresOn"]);

                acctFound.ResetCode = ds.Tables[0].Rows[0]["ResetCode"].ToString();

                if (ds.Tables[0].Rows[0]["ResetCodeExpiresOn"] == DBNull.Value)
                    acctFound.ResetCodeExpiresOn = DateTime.MinValue;
                else
                    acctFound.ResetCodeExpiresOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["ResetCodeExpiresOn"]);
            }

            return acctFound;
        }

        [HttpPost("Register")]
        public Account Register([FromBody] Account acct)
        {
            Account newAccount = null;

            if (acct == null)
            {
                return null;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_Register";
            cmd.Parameters.AddWithValue("@theUsername", acct.Username);
            cmd.Parameters.AddWithValue("@thePassword", acct.Password);
            cmd.Parameters.AddWithValue("@theFirstName", acct.FirstName);
            cmd.Parameters.AddWithValue("@theLastName", acct.LastName);
            cmd.Parameters.AddWithValue("@theEmail", acct.Email);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                newAccount = new Account();

                newAccount.MemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"]);
                newAccount.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                newAccount.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                newAccount.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                newAccount.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                newAccount.IsAccountActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAccountActive"]);
                newAccount.CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
                newAccount.IsEmailVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsEmailVerified"]);
            }

            return newAccount;
        }

        [HttpGet("GetMemberByID/{memberId}")]
        public Account GetMemberByID(int memberId)
        {
            Account acct = null;

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_GetByID";
            cmd.Parameters.AddWithValue("@theMemberID", memberId);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                acct = new Account();

                acct.MemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"]);
                acct.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                acct.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                acct.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                acct.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                acct.IsAccountActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAccountActive"]);
                acct.CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
                acct.IsEmailVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsEmailVerified"]);
                acct.VerificationCode = ds.Tables[0].Rows[0]["VerificationCode"].ToString();

                if (ds.Tables[0].Rows[0]["VerificationCodeExpiresOn"] == DBNull.Value)
                    acct.VerificationCodeExpiresOn = DateTime.MinValue;
                else
                    acct.VerificationCodeExpiresOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["VerificationCodeExpiresOn"]);

                acct.ResetCode = ds.Tables[0].Rows[0]["ResetCode"].ToString();

                if (ds.Tables[0].Rows[0]["ResetCodeExpiresOn"] == DBNull.Value)
                    acct.ResetCodeExpiresOn = DateTime.MinValue;
                else
                    acct.ResetCodeExpiresOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["ResetCodeExpiresOn"]);
            }

            return acct;
        }

        [HttpGet("GetUsernameByEmail/{email}")]
        public string GetUsernameByEmail(string email)
        {
            string username = "";

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_GetUsernameByEmail";
            cmd.Parameters.AddWithValue("@theEmail", email);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                username = ds.Tables[0].Rows[0]["Username"].ToString();
            }

            return username;
        }
        [HttpPost("AddSecurityAnswer")]
        public bool AddSecurityAnswer([FromBody] SecurityAnswer answer)
        {
            if (answer == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberSecurityAnswer_Add";
            cmd.Parameters.AddWithValue("@theMemberID", answer.MemberID);
            cmd.Parameters.AddWithValue("@theQuestionID", answer.QuestionID);
            cmd.Parameters.AddWithValue("@theAnswer", answer.Answer);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }

        [HttpGet("GetSecurityQuestionsByMemberID/{memberId}")]
        public List<SecurityQuestion> GetSecurityQuestionsByMemberID(int memberId)
        {
            List<SecurityQuestion> questions = new List<SecurityQuestion>();

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberSecurityQuestions_GetByMemberID";
            cmd.Parameters.AddWithValue("@theMemberID", memberId);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            foreach (DataRow row in ds.Tables[0].Rows)
            { 
                SecurityQuestion question = new SecurityQuestion();

                question.QuestionID = Convert.ToInt32(row["QuestionID"]);
                question.QuestionText = row["QuestionText"].ToString();

                questions.Add(question);
            }

            return questions;
        }

        [HttpPost("VerifySecurityAnswer")]
        public bool VerifySecurityAnswer([FromBody] SecurityAnswer answer)
        {
            if (answer == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MemberSecurityAnswer_Verify";
            cmd.Parameters.AddWithValue("@theMemberID", answer.MemberID);
            cmd.Parameters.AddWithValue("@theQuestionID", answer.QuestionID);
            cmd.Parameters.AddWithValue("@theAnswer", answer.Answer);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            return ds.Tables[0].Rows.Count > 0;
        }

        [HttpPost("StartPasswordReset")]
        public bool StartPasswordReset([FromBody] Account acct)
        {
            if (acct == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_StartPasswordReset";
            cmd.Parameters.AddWithValue("@theMemberID", acct.MemberID);
            cmd.Parameters.AddWithValue("@theResetCode", acct.ResetCode);
            cmd.Parameters.AddWithValue("@theResetCodeExpiresOn", acct.ResetCodeExpiresOn);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }

        [HttpPost("ResetPassword")]
        public bool ResetPassword([FromBody] Account acct)
        {
            if (acct == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_ResetPassword";
            cmd.Parameters.AddWithValue("@theMemberID", acct.MemberID);
            cmd.Parameters.AddWithValue("@theResetCode", acct.ResetCode);
            cmd.Parameters.AddWithValue("@theNewPassword", acct.Password);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }

        [HttpPost("VerifyEmail")]
        public bool VerifyEmail([FromBody] Account acct)
        {
            if (acct == null)
            {
                return false;
            }

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_VerifyEmail";
            cmd.Parameters.AddWithValue("@theMemberID", acct.MemberID);
            cmd.Parameters.AddWithValue("@theVerificationCode", acct.VerificationCode);

            int retVal = objDB.DoUpdateUsingCmdObj(cmd);
            return retVal > 0;
        }
        [HttpGet("GetMemberByUsername/{username}")]
        public Account GetMemberByUsername(string username)
        {
            Account acct = null;

            DBConnect objDB = new DBConnect();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Member_GetByUsername";
            cmd.Parameters.AddWithValue("@theUsername", username);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                acct = new Account();

                acct.MemberID = Convert.ToInt32(ds.Tables[0].Rows[0]["MemberID"]);
                acct.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                acct.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                acct.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                acct.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                acct.IsAccountActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAccountActive"]);
                acct.CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
                acct.IsEmailVerified = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsEmailVerified"]);
                acct.VerificationCode = ds.Tables[0].Rows[0]["VerificationCode"].ToString();

                if (ds.Tables[0].Rows[0]["VerificationCodeExpiresOn"] == DBNull.Value)
                    acct.VerificationCodeExpiresOn = DateTime.MinValue;
                else
                    acct.VerificationCodeExpiresOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["VerificationCodeExpiresOn"]);

                acct.ResetCode = ds.Tables[0].Rows[0]["ResetCode"].ToString();

                if (ds.Tables[0].Rows[0]["ResetCodeExpiresOn"] == DBNull.Value)
                    acct.ResetCodeExpiresOn = DateTime.MinValue;
                else
                    acct.ResetCodeExpiresOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["ResetCodeExpiresOn"]);
            }

            return acct;
        }
    }
}


