using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>>;

namespace Corset.Core.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCorset(this IApplicationBuilder builder, CorsetOptions options)
        {   
            return builder.UseMiddleware<CorsetMiddleware>();
        }

        
    }
}