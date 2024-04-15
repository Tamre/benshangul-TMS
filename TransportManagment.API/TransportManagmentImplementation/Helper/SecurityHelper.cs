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
    }
}
