using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Corset.Core.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseCorset(this IAppBuilder builder)
        {
            return builder.Use<CorsetMiddleware>();
        }
    }
}