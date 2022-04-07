using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace rock_paper_scissors
{
    class Crypto
    {
        public static string key = ""; // key to show to User after his move
        public static void GenerateRandomKey()
        {
            byte[] salt = new byte[32]; // 32 bytes = 256 bit
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            key = GetStringFromHash(salt);
        }
        public static string GetHash(string text)
        {
            GenerateRandomKey();
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);
            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return GetStringFromHash(hashBytes);
        }
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString().ToLower();
        }
    }
}
