using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Utilities
{
    public static class Helper
    {
        public static string GetSha256(string value)
        {
            SHA256 sHA256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sHA256.ComputeHash(encoding.GetBytes(value));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);               
            }
            return sb.ToString();
        }
    }
}
