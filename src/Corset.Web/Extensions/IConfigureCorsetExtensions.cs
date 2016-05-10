using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Corset.Core;
using Corset.Core.Configuration;
using Corset.Web.Configuration;
using Corset.Web.Extensions;
using Corset.Web.Handlers;

namespace Corset.Web.Extensions
{
    public static class IConfigureCorsetExtensions {
        
        public static IConfigureCorset<HttpRequestBase, HttpResponseBase> ForCss(this IConfigureCorset<HttpRequestBase, HttpResponseBase> corset, Expression<ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>> action)
        {
            return corset.For((req, resp) => IsCssRequest(req, resp), action);
        }

        private static bool IsCssRequest(HttpRequestBase req, HttpResponseBase resp) {
            return resp.ContentType.Equals("text/css", StringComparison.InvariantCultureIgnoreCase);
        }

    }
}
