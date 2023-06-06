using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedInfoservices.Utils
{
    public class Hash
    {
        #region SHA-512

        public static String SHA512(String input)
        {
            return SHA512(UTF8Encoding.UTF8.GetBytes(input));
        }

        public static String SHA512(Byte[] input)
        {
            using (System.Security.Cryptography.SHA512 hash =
                System.Security.Cryptography.SHA512.Create())
            {
                return BitConverter.ToString(hash.ComputeHash(input))
                    .Replace("-", "").ToLower();
            }
        }

        #endregion

    }
}
