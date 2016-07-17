using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Corset.Core.Configuration;

namespace Corset.Core
{
    /// <summary>
    /// Placeholder class, everything is implemented via extensions
    /// </summary>
    public abstract class ConfigureCorsetCore<T1, T2> : IConfigureCorset<T1, T2>
        where T1 : class
        where T2 : class
    {
        private static IList<ICorsetHandler<T1, T2>> _handlers = new List<ICorsetHandler<T1, T2>>();

        public IList<ICorsetHandler<T1, T2>> Handlers { get { return _handlers; } }
    }
}
