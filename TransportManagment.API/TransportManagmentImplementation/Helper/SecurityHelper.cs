using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.Helper
{
    public static class SecurityHelper
    {
        public static string GenerateHmacSha512Key(int keySizeInBits)
        {
            byte[] keyBytes = new byte[keySizeInBits / 8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }


        // Encrypts text using a Caesar cipher with the given key
        public static string CaesarCipherEncrypt(string str, int key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                int code = (int)ch;
                // Encrypt characters
                code = (code + key) % 65536; // 65536 is the number of characters in Unicode
                ch = (char)code;
                result.Append(ch);
            }
            return result.ToString();
        }

        public static string CaesarCipherDecrypt(string str, int key)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                int code = (int)ch;
                // Decrypt characters
                code = (code - key + 65536) % 65536; // 65536 is the number of characters in Unicode
                ch = (char)code;
                result.Append(ch);
            }
            return result.ToString();
        }



    }
}
