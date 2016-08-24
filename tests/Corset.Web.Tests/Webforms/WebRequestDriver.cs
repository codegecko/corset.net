using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace Corset.Web.Tests.Webforms
{
    public class WebRequestDriver : MarshalByRefObject
    {
        public void Go(string hostname, string page, string queryString) {
            var sw = new StringWriter();
            var wr = new SimpleWorkerRequest(page, queryString, sw);
            // This causes ASP.NET to process the request
            HttpRuntime.ProcessRequest(wr);
        }

        public void Done() {
            HttpRuntime.Close();
        }
    }
}
