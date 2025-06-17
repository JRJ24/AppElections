
using System.Text;
using System.Security.Cryptography;

namespace Sadvo.Application.Helpers
{
    public class PasswordEncrypted
    {
        public static string ComputeSha256Hash(string password)
        {
            //Create a SHA256
            using SHA256 sha256Hash = SHA256.Create();
            //ComputeHash
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Convert byte array to a string
            StringBuilder sb = new();

            foreach (var item in bytes)
            {
                sb.Append(item.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
