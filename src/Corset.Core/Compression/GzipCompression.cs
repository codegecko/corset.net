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
    public class GzipCompression : ICompression
    {
        public string AcceptType => "gzip";

        public string Compress(Stream content, Encoding encoding) {
            using (var compressStream = new GZipStream(content, CompressionMode.Compress)) {
                return compressStream.ToReadableString(encoding);
            }
        }
    }
}
