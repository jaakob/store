using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace PhoneStore.Security
{
    public class SecurityHelper
    {
        public static string GetHashSha256(string value)
        {
            byte[] byteResult = Encoding.UTF8.GetBytes(value);
            SHA256Managed hash = new SHA256Managed();
            byte[] bytesHash = hash.ComputeHash(byteResult);
            StringBuilder builder = new StringBuilder();

            foreach (byte x in bytesHash)
            {
                builder.Append(String.Format("{0:x2}", x));
            }

            return builder.ToString();
        }
    }
}
