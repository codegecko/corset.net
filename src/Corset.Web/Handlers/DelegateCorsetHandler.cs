using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Corset.Core;
using Corset.Core.Configuration;

namespace Corset.Web.Handlers
{
    internal sealed class DelegateCorsetHandler : ICorsetHandler<HttpRequestBase, HttpResponseBase>
    {

        public DelegateCorsetHandler(Expression<Func<HttpRequestBase, HttpResponseBase, bool>> supported, ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase> handlers) {
            this.Supported = supported.Compile();
            this.Actions = handlers.Actions;
        }

        public IEnumerable<Action<HttpRequestBase, HttpResponseBase>> Actions { get; private set; }

        public Func<HttpRequestBase, HttpResponseBase, bool> Supported { get; private set; }
    }
}
