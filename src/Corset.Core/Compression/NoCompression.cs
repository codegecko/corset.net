using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public class NoCompression : ICompression
    {
        public string AcceptType => "";
        
        public string Compress(Stream content) {
            using (var sr = new StreamReader(content)) {
                return sr.ReadToEnd();
            }
        }
    }
}
