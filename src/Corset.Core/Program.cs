using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corset.Core
{
    public class Program
    {
        public static void Main(params string[] args)
        {

            Console.WriteLine($"Compression enabled: {Utilities.IsDynamicCompressionInstalled().ToString()}");
            Console.ReadLine();
        }
    }
}
