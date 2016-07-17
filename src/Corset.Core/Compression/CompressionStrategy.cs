using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core.Compression
{
    public class CompressionStrategy
    {

        private ICompression nullRef = null;

        public List<ICompression> Modules = new List<ICompression>();

        public static CompressionStrategy Use<T>() where T : ICompression
        {
            return new CompressionStrategy().ThenUse<T>();
        }

        public CompressionStrategy ThenUse<T>() where T : ICompression
        {
            Modules.Add(Activator.CreateInstance<T>());
            return this;
        }

        public void FallbackTo<T>() where T : ICompression
        {
            nullRef = Activator.CreateInstance<T>();
        }
    }
}
