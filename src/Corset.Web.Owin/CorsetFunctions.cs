using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace Corset.Web.Owin
{
    public class CorsetOwinFunctions : Dictionary<Func<IOwinRequest, IOwinResponse, bool>, Func<IOwinResponse>>
    {

    }
}
