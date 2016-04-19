using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corset.Core.Extensions;

namespace Corset.Core.Compression
{
    public class DeflateCompression : ICompression
    {
        public string AcceptType => "deflate";

        public string Compress(Stream content, Encoding encoding) {
            using (var compressStream = new DeflateStream(content, CompressionMode.Compress)) {
                return compressStream.ToReadableString(encoding);
            }
        }
    }
}
