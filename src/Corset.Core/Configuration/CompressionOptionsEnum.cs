using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Configuration
{
    public enum CompressionOptions
    {
        None,
        GZip,
        Deflate,
        Brotli
    }
}
