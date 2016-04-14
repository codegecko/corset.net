using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public class BrotliCompression : ICompression
    {
        public string Compress(Stream content)
        {
            throw new NotImplementedException();
        }

        public string AcceptType => "br";
    }
}
