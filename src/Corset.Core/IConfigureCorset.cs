using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Corset.Core.Configuration;

namespace Corset.Core
{
    public interface IConfigureCorset<T1, T2>
        where T1 : class
        where T2 : class
    {
        IList<Action<T1, T2>> Handlers { get; }

        Expression<Action<T1, T2>> Use(Expression<Action<T1, T2>> action);
    }
}