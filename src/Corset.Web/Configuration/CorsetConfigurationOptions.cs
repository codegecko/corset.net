using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using Corset.Core.Configuration;

namespace Corset.Web
{
    public class CorsetConfigurationOptions : ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase>
    {
        private IList<Action<HttpRequestBase, HttpResponseBase>> _actions = new List<Action<HttpRequestBase, HttpResponseBase>>();

        public IList<Action<HttpRequestBase, HttpResponseBase>> Actions { get { return _actions; } }

        public ICorsetConfigurationOptions<HttpRequestBase, HttpResponseBase> Use(Expression<Action<HttpRequestBase, HttpResponseBase>> handler)
        {
            Actions.Add(handler.Compile());
            return this;
        }
    }
}
