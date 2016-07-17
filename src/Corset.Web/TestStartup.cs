using System;
using System.Web;
using Corset.Core.Compression;
using Corset.Web.Configuration;
using Corset.Web.Extensions;


namespace Corset.Web
{
    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            var del = ConfigureCorset.ForCss(opt => opt.EnableEtags(ETagStrategy.SHA256)
                                                       .SetCacheControl("private"))
                                    .ForJavascript(opt => )
        }
    }
}
