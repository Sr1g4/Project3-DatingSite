using System.Security.Cryptography;
using System.Text;

namespace DatingSiteLibrary
{
    public class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            if (password == null)
            {
                return "";
            }

            SHA256 sha = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}