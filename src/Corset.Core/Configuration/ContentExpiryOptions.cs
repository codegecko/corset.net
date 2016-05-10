using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Configuration
{
    public class ContentExpiryOptions
    {

        private static DateTime FixedExpiry = DateTime.UtcNow.Add(RollingExpiry);

        private static TimeSpan RollingExpiry = TimeSpan.FromMinutes(1d);
    }
}
