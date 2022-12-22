using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Public class for encrypting strings
/// Primarily used for code reuse
/// </summary>

namespace BusinessLogicLayer.Helpers
{
    public static class StringExtensions
    {
        public static string Sha256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
