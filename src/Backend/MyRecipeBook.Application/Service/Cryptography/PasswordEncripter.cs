using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Application.Service.Cryptography
{
     public class PasswordEncripter
    {
        public string Encrypt(string password)
        {
            var chaveAdicional = "ABz";

            var newPassword = $"{password}{chaveAdicional}";

            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
        
    }
}
