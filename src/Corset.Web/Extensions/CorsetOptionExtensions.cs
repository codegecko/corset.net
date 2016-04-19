using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Corset.Web.Extensions
{
    public static class CorsetOptionExtensions
    {

        public ICorsetOptions ForCss()
        {
            var ctxWrapper = new HttpContextWrapper(HttpContext.Current);
            return IsCss(ctxWrapper.Request, ctxWrapper.Response);
        }

        private bool IsCss(HttpRequestBase request, HttpResponseBase response) {
            return response.ContentType.Equals("text/css", StringComparison.CurrentCultureIgnoreCase);
        }


    }
}
