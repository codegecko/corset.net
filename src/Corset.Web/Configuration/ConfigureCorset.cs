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

        static ConfigureCorset()
        {
            Instance = Instance ?? new ConfigureCorset();
        }

        private static ConfigureCorset Instance { get; set; }

        public ConfigureCorset For(TestExpr test, Expression<ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>> action)
        {
            // Instance.Handlers.Add(new SingleEventHandler(test.Compile(), action.Compile()));
            return Instance;
        }

        public ConfigureCorset For<T>() where T : ICorsetHandler<HttpRequestBase, HttpResponseBase>, new()
        {
            Instance.Handlers.Add(new T());
            return Instance;
        }
    }
}
