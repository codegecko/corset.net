using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Hashing
{
    public interface IETagGenerator
    {
        Func<string, string> GenerateTag { get; set; }
    }
}
