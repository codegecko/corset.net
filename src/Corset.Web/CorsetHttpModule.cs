using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Corset.Web
{
    public class CorsetHttpModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            foreach (var req in Corset.Core.CorsetOptions.Current.Invocations) {
                if (req.Key(app.Request, app.Response)) req.Value();
            }
        }
    }
}
