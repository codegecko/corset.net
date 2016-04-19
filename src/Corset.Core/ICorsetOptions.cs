using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core
{
    public interface ICorsetOptions<T1, T2>
        where T1 : class, new()
        where T2: class, new() {

        Dictionary<Func<T1, T2, bool>, Func<T2>> Invocations { get; set; }

    }
}
