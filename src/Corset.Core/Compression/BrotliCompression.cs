using System;
using System.IO;
using System.Text;

namespace Corset.Core.Compression
{
    public class BrotliCompression : ICompression
    {
        public string AcceptType { get { throw new NotImplementedException(); } }

        public string Compress(Stream content, Encoding encoding) { throw new NotImplementedException(); }
    }
}
