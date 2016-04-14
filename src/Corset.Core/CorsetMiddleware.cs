using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core.Compression;
using Corset.Core.Hashing;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Corset.Core
{
    public class CorsetMiddleware
    {
        public AppFunc Next { get; set; }

        public CorsetMiddleware(AppFunc next)
        {
            Next = next;
        }

        public void Initialize(AppFunc next)
        {
            Next = Next ?? next;
        }


        public async Task Invoke(IDictionary<string, object> environment)
        {
            // var context = new OwinContext(environment);

            var strategy = CompressionStrategy.Use<GzipCompression>()
                                            .ThenUse<DeflateCompression>()
                                            .ThenUse<NoCompression>();
            var etagStrategy = ETagStrategy.Use<MD5HashGenerator>();
            Next.Invoke(environment);
        }

    }
}
