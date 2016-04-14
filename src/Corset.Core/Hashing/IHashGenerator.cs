using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Corset.Core.Hashing
{
    interface IHashGenerator
    {
        string Alias { get; }

        string GenerateHash(string textToHash, string encodingName);
    }
}
