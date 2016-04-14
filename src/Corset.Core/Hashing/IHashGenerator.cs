using System;

namespace Corset.Core.Hashing
{
    interface IHashGenerator
    {
        string Alias { get; }

        string GenerateHash(string textToHash, string encodingName);
    }
}
