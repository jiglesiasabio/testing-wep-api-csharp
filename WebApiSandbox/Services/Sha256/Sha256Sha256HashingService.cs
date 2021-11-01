using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApiSandbox.Services
{
    public class Sha256Sha256HashingService: Sha256HashingServiceInterface
    {
        public string Hash(string clearText)
        {
            if (String.IsNullOrEmpty(clearText))
            {
                throw new ArgumentException("String cannot be empty");
            }

            return createSha256Hash(clearText);
        }

        private string createSha256Hash(string clearText)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(clearText));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }

            return hash;
        }
    }
}