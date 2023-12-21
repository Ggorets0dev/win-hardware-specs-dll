using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WinHardwareSpecs;

namespace FunctionalityTest
{
    internal class Program
    {
        static void Main()
        {
            var specification = SpecMonitor.GetSpecification();
            Console.WriteLine(specification.ToJson());

            Console.ReadLine();
        }
    }
}
