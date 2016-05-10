using System;
using System.IO;
using System.Web;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace Corset.Web
{
    /// <summary>
    /// Removes whitespace from the webpage.
    /// </summary>
    public class WhitespaceModule : IHttpModule {

        #region IHttpModule Members

        void Dispose() {
            // Nothing to dispose; 
        }

        void Init(HttpApplication context) {
            context.BeginRequest += context_BeginRequest;
        }

        #endregion

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app.Response.ContentType.Contains("text/html")) {
                app.Response.Filter = new HtmlWhitespaceFilter(app.Response.Filter);
            }
        }
    }

}