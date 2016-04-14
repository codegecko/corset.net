using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core.Configuration;
using Corset.Core.Compression;

namespace Corset.Core
{
    public class CorsetOptions
    {

        public class CSSCompressionOptions
        {
            public ICompression Method { get; set; }

            public bool SaveCssToDisk { get; set; }
        }
    }
}
