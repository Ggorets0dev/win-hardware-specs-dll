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
            // Console.WriteLine(SpecMonitor.GetHardwareInfo("Win32_PhysicalMemory", "Speed").Count);

            foreach (var centralProcessingUnitObject in SpecMonitor.GetCentralProcessingUnits())
            {
                centralProcessingUnitObject.Print();
                Console.WriteLine("\n-------------------------------\n");
            }

            foreach (var graphicalProcessingUnitObject in SpecMonitor.GetGraphicalProcessingUnits())
            {
                graphicalProcessingUnitObject.Print();
                Console.WriteLine("\n-------------------------------\n");
            }

            foreach (var physcialMemoryObject in SpecMonitor.GetPhysicalMemory())
            {
                physcialMemoryObject.Print();
                Console.WriteLine("\n-------------------------------\n");
            }

            foreach (var operatingSystemObject in SpecMonitor.GetOperatingSystems())
            {
                operatingSystemObject.Print();
                Console.WriteLine("\n-------------------------------\n");
            }

            Console.ReadLine();
        }
    }
}
