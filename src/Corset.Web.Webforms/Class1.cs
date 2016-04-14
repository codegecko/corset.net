using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Corset.Web.Webforms
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class CorsetHttpModule : IHttpModule
    {
        public CorsetHttpModule()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += GenerateEtag
        }

        private void GenerateHash(object sender, EventArgs e)
        {
            var app = (HttpApplication) sender;
            var ctx = app.Context.Response.OutputStream;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
