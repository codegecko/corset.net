using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Corset.Core;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Corset.Web.Owin
{
    public static class AppBuilderExtensions
    {
#if !DOTNET5_4
        public static IAppBuilder UseCorset(this IAppBuilder builder, Func<CorsetOptions, Task> options)
        {
            return builder.Use<CorsetMiddleware>();
        }
#else
        public static IApplicationBuilder UseCorset(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsetMiddleware>();
        }
#endif
    }
}