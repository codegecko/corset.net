using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public class DeflateCompression : ICompression
    {
        public string Compress(Stream content)
        {
            var responseStream = new DeflateStream(content, CompressionMode.Compress);
            using (var sr = new StreamReader(responseStream)) {
                return sr.ReadToEnd();
            }
        }

        public string AcceptType => "deflate";
    }
}
