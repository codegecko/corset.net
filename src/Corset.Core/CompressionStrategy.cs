using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corset.Core.Compression;

namespace Corset.Core
{
    public class CompressionStrategy
    {
        internal CompressionStrategy(List<Type> list)
        {
            OrderOfCompression = list;
        }

        internal List<Type> OrderOfCompression;

        public CompressionStrategy ThenUse<T>() where T : ICompression
        {
            OrderOfCompression.Add(typeof(T));
            return this;
        }

        public static CompressionStrategy New<T>() where T : ICompression
        {
            return new CompressionStrategy(new List<Type>()).ThenUse<T>();
        }
    }
}
