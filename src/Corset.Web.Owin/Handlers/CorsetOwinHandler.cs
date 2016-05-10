using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core;
using Microsoft.Owin;

namespace Corset.Web.Owin.Handlers
{
    public abstract class CorsetOwinHandler : ICorsetHandler<IOwinRequest, IOwinResponse>
    {
        public abstract Func<IOwinRequest, IOwinResponse, bool> CanHandle { get; }
        public abstract Action<IOwinRequest, IOwinResponse> Handler { get; }
    }
}
