using System;
using System.Security.Cryptography;
using System.Text;

namespace SoapUtils.Utils
{
    public static class HashUtils
    {
        public static string HmacSHA256(string message, string key)
        {
            string sign = "";

            UTF8Encoding encoding = new UTF8Encoding();

            byte[] keyBytes     = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);

            using (HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashMessage = hmacsha256.ComputeHash(messageBytes);
                sign = BitConverter.ToString(hashMessage).Replace("-", "").ToLower();;
            }

            return sign;
        }
    }
}