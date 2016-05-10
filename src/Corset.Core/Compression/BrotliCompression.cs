using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public class BrotliCompression : ICompression
    {
        public string AcceptType { get { throw new NotImplementedException(); } }

        public string Compress(Stream content, Encoding encoding) { throw new NotImplementedException(); }
    }
}
