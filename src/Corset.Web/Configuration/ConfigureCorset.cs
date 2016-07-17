using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Corset.Core;
using Corset.Core.Configuration;
using Corset.Web.Configuration;
using Corset.Web.Handlers;
using TestExpr = System.Linq.Expressions.Expression<System.Func<System.Web.HttpRequestBase, System.Web.HttpResponseBase, bool>>;

namespace Corset.Web.Configuration
{
    public class ConfigureCorset : ConfigureCorsetCore<HttpRequestBase, HttpResponseBase> {

        private static ConfigureCorset Instance => new ConfigureCorset();

        public static ConfigureCorset For(TestExpr test, Expression<ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>> action)
        {
            Instance.Handlers.Add(new MultipleEventHandler(test.Compile(), action.Compile().Actions));
            return Instance;
        }

        public static ConfigureCorset For<T>() where T : ICorsetHandler<HttpRequestBase, HttpResponseBase>, new()
        {
            Instance.Handlers.Add(new T());
            return Instance;
        }

        public static ConfigureCorset ForCss(Expression<ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>> action) {
            return For((req, resp) => IsCssRequest(req, resp), action);
        }

        public static ConfigureCorset ForJavascript(Expression<ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>> action) {
            return For((req, resp) => IsJavascriptRequest(req, resp), action);
        }

        public static ConfigureCorset ForPng(Expression<ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>> action) {
            return For((req, resp) => IsPngRequest(req, resp), action);
        }

        private static bool IsCssRequest(HttpRequestBase req, HttpResponseBase resp) {
            return resp.ContentType.Equals("text/css", StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool IsJavascriptRequest(HttpRequestBase req, HttpResponseBase resp) {
            return resp.ContentType.IndexOf("javascript") > -1 || req.PhysicalPath.EndsWith("js");
        }

        private static bool IsPngRequest(HttpRequestBase req, HttpResponseBase resp) {
            return resp.ContentType.IndexOf("png") > -1 || req.PhysicalPath.EndsWith("png");
        }
    }
}
