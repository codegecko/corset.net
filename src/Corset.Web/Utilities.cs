using System.Collections.Generic;
using System.Linq;
#if DOTNET4
using System.Management;
#endif
using System.Threading.Tasks;

namespace Corset.Core
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class Utilities
    {
        private static bool? _isDynamicCompressionInstalled;

        public static bool IsDynamicCompressionInstalled()
        {

#if DOTNET4
            if (_isDynamicCompressionInstalled.HasValue)
                return _isDynamicCompressionInstalled.Value;

            var mgmtScope = new ManagementScope("root\\cimv2");
            mgmtScope.Connect();

            var pathToFeature = new ManagementPath(
                string.Concat(mgmtScope.Path, ":Win32_OptionalFeature.Name=\"IIS-HttpCompressionDynamic\""));

            var feature = new ManagementObject(pathToFeature);
            feature.Get();

            _isDynamicCompressionInstalled = ((int)feature["InstallState"] == 1);
#else
            _isDynamicCompressionInstalled = true;
#endif
            return _isDynamicCompressionInstalled.Value;
        }
    }
}
