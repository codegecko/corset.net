using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public interface ICompression
    {
        string Compress(Stream content);

        string AcceptType { get; }
    }
}
