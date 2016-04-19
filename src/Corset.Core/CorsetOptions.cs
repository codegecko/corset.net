using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core.Compression;
using Corset.Core.Configuration;

namespace Corset.Core
{
    public class CorsetOptions : ICorsetOptions
    {

        private static CorsetOptions _current = new CorsetOptions();
        public static CorsetOptions Current { get { return _current; } }

        public Dictionary<Func<object, object, bool>, Func<object>> Invocations = new Dictionary<Func<object, object, bool>, Func<object>>();
    }
}
