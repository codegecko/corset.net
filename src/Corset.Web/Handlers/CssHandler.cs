using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Corset.Core;

namespace Corset.Web.Handlers
{
    public sealed class CssHandler : AbstractCorsetHandler
    {
        public override IEnumerable<Action<HttpRequestBase, HttpResponseBase>> Actions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Func<HttpRequestBase, HttpResponseBase, bool> Supported {
            get {
                return (request, response) => {
                    return response.ContentType.Equals("text/css", StringComparison.InvariantCultureIgnoreCase);
                };
            }
        }
    }
}
