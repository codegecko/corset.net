using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corset.Core.Extensions {
    public static class StreamExtensions {

        public static string ToReadableString(this Stream stream) {
            return stream.ToReadableString(Encoding.Unicode);
        }

        public static string ToReadableString(this Stream stream, Encoding encoding) {
            if (!stream.CanRead) throw new ArgumentException("Stream must be readable");
            if (!stream.CanSeek) throw new ArgumentException("Stream must be seekable to beginning");
            stream.Seek(0, SeekOrigin.Begin);
            using (var sr = new StreamReader(stream, encoding)) {
                return sr.ReadToEnd();
            }
        }

    }
}
