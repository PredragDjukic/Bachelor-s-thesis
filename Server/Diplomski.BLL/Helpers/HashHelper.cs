using System.Runtime.CompilerServices;
using Diplomski.BLL.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace Diplomski.BLL.Helpers
{
    public static class HashHelper
    {
        
        public static bool IsValueEqualToHash(string value, string existingHash)
        {
            string newHash = HashValue(value);

            return newHash == existingHash ? true : false;
        }
        
        public static string HashValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new BusinessException("Can not hash empty string or null", HttpStatusCode.BadRequest);

            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                    
                StringBuilder builder = new StringBuilder();

                for(int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
