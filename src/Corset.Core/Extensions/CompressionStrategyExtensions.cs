using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core.Compression;

namespace Corset.Core.Extensions
{
    public static class CompressionStrategyExtensions
    {
        public static ICompression Get(this CompressionStrategy strategy, string compressionCode) {
            return strategy.ListOfModules.DefaultIfEmpty(strategy.nullRef)
                                .SingleOrDefault(p => p.AcceptType.Equals(compressionCode));
        }

        public static ICompression GetFirstAvailable(this CompressionStrategy strategy, string[] compressionCodes) {
            foreach (var compression in compressionCodes) {
                Func<ICompression, bool> test = (c => c.AcceptType.Equals(compression, StringComparison.CurrentCultureIgnoreCase));

                if (strategy.ListOfModules.Any(test)) {
                    return strategy.ListOfModules.Single(test);
                } else {
                    continue;
                }
            }
            return strategy.nullRef;
        }
    }
}
