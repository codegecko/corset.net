using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core;

namespace Corset.Core
{
    public interface ICorsetHandler : ICorsetHandler<object, object>
    {
        Func<object, object, bool> Supported { get; }

        IEnumerable<Action<object, object>> Actions { get; }
    }

    public interface ICorsetHandler<T1, T2>
        where T1 : class
        where T2 : class
    {

        Func<T1, T2, bool> Supported { get; }

        IEnumerable<Action<T1, T2>> Actions { get; }
    }
}
