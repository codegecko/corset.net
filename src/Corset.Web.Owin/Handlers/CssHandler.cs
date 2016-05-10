using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corset.Core;
using Corset.Core.Compression;
using Corset.Web.Owin.Handlers;
using Microsoft.Owin;

namespace Corset.Web.Owin.Handlers
{
    public class CssHandler : CorsetOwinHandler
    {
        public override Func<IOwinRequest, IOwinResponse, bool> CanHandle {
            get {
                return (request, response) => {
                    return response.ContentType.Equals("text/css", StringComparison.InvariantCultureIgnoreCase);
                };
            }
        }

        public override Action<IOwinRequest, IOwinResponse> Handler {
            get {
                return (request, response) => {
                    var strategy = CompressionStrategy.GetFirstAvailable(request.Accept.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                    var encoding = Encoding.Default;
                    var responseBytes = encoding.GetBytes(strategy.Compress(response.Body, encoding));
                    response.Body = new MemoryStream(responseBytes);
                };
            }
        }
    }
}
