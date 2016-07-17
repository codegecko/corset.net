using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corset.Core.Extensions {
    public static class StreamExtensions {

        public static string ToReadableString(this Stream stream) {
            #if DOTNET4
            var enc = Encoding.Default;
            #elif DOTNET5
            var enc = Encoding.UTF8;
            #endif
            return stream.ToReadableString(enc);
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
