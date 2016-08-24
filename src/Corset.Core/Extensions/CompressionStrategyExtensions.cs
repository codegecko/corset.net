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
            return strategy.Modules.DefaultIfEmpty(strategy.nullRef)
                                .SingleOrDefault(p => p.AcceptType.Equals(compressionCode));
        }

        public static ICompression GetFirstAvailable(this CompressionStrategy strategy, string[] compressionCodes) {
            foreach (var compression in compressionCodes) {
                Func<ICompression, bool> test = (c => c.AcceptType.Equals(compression, StringComparison.CurrentCultureIgnoreCase));

                if (strategy.Modules.Any(test)) {
                    return strategy.Modules.Single(test);
                } else {
                    continue;
                }
            }
            return strategy.nullRef;
        }
    }
}
