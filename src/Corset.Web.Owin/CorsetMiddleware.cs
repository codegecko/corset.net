using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Corset.Core
{
    public class CorsetMiddleware
    {
        public AppFunc Next { get; set; }

        private CorsetOptions Options { get; set; }

        public CorsetMiddleware(AppFunc next, CorsetOptions options)
        {
            Next = next;
        }

        public void Initialize(AppFunc next)
        {
            Next = Next ?? next;
        }


        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            await Next.Invoke(environment);
            ctx.Response.OnSendingHeaders(state => {
                
            });
        }

    }
}
