using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Corset.Core;

namespace Corset.Web.Configuration
{
    internal class MultipleEventHandler : ICorsetHandler<HttpRequestBase, HttpResponseBase>
    {
        private IList<Action<HttpRequestBase, HttpResponseBase>> _actions;
        private Func<HttpRequestBase, HttpResponseBase, bool> _func;

        public MultipleEventHandler(Func<HttpRequestBase, HttpResponseBase, bool> func, IList<Action<HttpRequestBase, HttpResponseBase>> actions)
        {
            this._func = func;
            this._actions = actions;
        }

        public IEnumerable<Action<HttpRequestBase, HttpResponseBase>> Actions { get { return _actions.AsEnumerable(); } }

        public Func<HttpRequestBase, HttpResponseBase, bool> Supported { get { return _func; } }
    }
}