using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public class CompressionStrategy
    {

        private static ICompression nullRef = null;

        internal static List<ICompression> ListOfModules = new List<ICompression>();

        public static CompressionStrategy Use<T>() where T : ICompression
        {
            return new CompressionStrategy().ThenUse<T>();
        }

        public CompressionStrategy ThenUse<T>() where T : ICompression
        {
            ListOfModules.Add(Activator.CreateInstance<T>());
            return this;
        }

        public static ICompression Get(string compressionCode) {
            return ListOfModules.DefaultIfEmpty(nullRef)
                                .SingleOrDefault(p => p.AcceptType.Equals(compressionCode));
        }

        public static ICompression GetFirstAvailable(string[] compressionCodes)
        {
            foreach(var compression in compressionCodes)
            {
                return ListOfModules.DefaultIfEmpty(nullRef)
                                    .FirstOrDefault(c => c.AcceptType.Equals(compression, StringComparison.CurrentCultureIgnoreCase));
            }
            return nullRef;
        }
    }
}
