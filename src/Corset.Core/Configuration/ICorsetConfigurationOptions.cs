﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Configuration
{
    public interface ICorsetConfigurationOptions<T1, T2>
        where T1 : class
        where T2 : class
    {
        IList<Action<T1, T2>> Actions{ get; }
    }
}
