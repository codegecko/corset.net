using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Corset.Core;

namespace Corset.Web.Handlers
{
    public abstract class AbstractCorsetHandler : ICorsetHandler<HttpRequestBase, HttpResponseBase>
    {
        public abstract IEnumerable<Action<HttpRequestBase, HttpResponseBase>> Actions { get; }

        public abstract Func<HttpRequestBase, HttpResponseBase, bool> Supported { get; }
    }
}
