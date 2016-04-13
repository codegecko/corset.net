using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>>;

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


        public static async Task Invoke(IDictionary<string, object> environment)
        {
            await Next.Invoke(environment);
        }

    }
}
