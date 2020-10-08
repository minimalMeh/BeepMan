using System;
using System.Text;
using System.Security.Cryptography;

namespace BeepMan.Api.Servicies
{
    public static class CryptoService
    {
        public static string CalculateHash(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var encodedvalue = Encoding.Unicode.GetBytes(password);
                var hash = sha.ComputeHash(encodedvalue);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
