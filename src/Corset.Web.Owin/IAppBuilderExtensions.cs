using System;
using Owin;

namespace Corset.Core.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IAppBuilder UseCorset(this IAppBuilder builder, Func<CorsetOptions> options) {
            return builder.UseCorset(options.Invoke());
        }
        public static IAppBuilder UseCorset(this IAppBuilder builder, CorsetOptions options) {
            return builder.Use<CorsetMiddleware>(options);
        }
    }
}