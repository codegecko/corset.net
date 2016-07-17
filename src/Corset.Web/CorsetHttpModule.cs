using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Corset.Web.Configuration;

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
            context.PreSendRequestHeaders += Context_PreSendRequestHeaders;
        }

        private void Context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var ctx = new HttpContextWrapper(app.Context);
            foreach (var handler in ConfigureCorset.Instance.Handlers) {
                if (handler.Supported(ctx.Request, ctx.Response)) {
                    foreach (var action in handler.Actions) {
                        action(ctx.Request, ctx.Response);
                    }
                }
            }
        }
    }
}
