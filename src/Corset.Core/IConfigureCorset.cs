using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Corset.Core
{
    public interface IConfigureCorset<T1, T2>
        where T1 : class
        where T2 : class
    {
        IList<ICorsetHandler<T1, T2>> Handlers { get; }
    }
}