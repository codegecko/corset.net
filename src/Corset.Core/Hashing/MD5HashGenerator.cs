using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Corset.Core.Hashing
{
    public class MD5HashGenerator : IHashGenerator
    {
        public string Alias => "md5";
        public string GenerateHash(string textToHash, string encodingName = "utf8")
        {
            var md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(Encoding.GetEncoding(encodingName).GetBytes(textToHash));
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }
    }
}
