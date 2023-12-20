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
        static void Main(string[] args)
        {
            // Console.WriteLine(SpecMonitor.GetHardwareInfo("Win32_PhysicalMemory", "PartNumber")[0]);

            var cpu = new CentralProcessorUnit(
                name: SpecMonitor.GetHardwareInfo(CentralProcessorUnit.systemName, "Name")[0],
                description: SpecMonitor.GetHardwareInfo(CentralProcessorUnit.systemName, "Description")[0],
                manufacturer: SpecMonitor.GetHardwareInfo(CentralProcessorUnit.systemName, "Manufacturer")[0],
                baseClockSpeed: ushort.Parse(SpecMonitor.GetHardwareInfo(CentralProcessorUnit.systemName, "CurrentClockSpeed")[0]),
                numberOfCores: byte.Parse(SpecMonitor.GetHardwareInfo(CentralProcessorUnit.systemName, "NumberOfCores")[0]),
                numberOfLogicalProcessors: byte.Parse(SpecMonitor.GetHardwareInfo(CentralProcessorUnit.systemName, "NumberOfLogicalProcessors")[0])
            );

            var gpu = new GraphicsProcessingUnit(
                name: SpecMonitor.GetHardwareInfo(GraphicsProcessingUnit.systemName, "Name")[0],
                description: SpecMonitor.GetHardwareInfo(GraphicsProcessingUnit.systemName, "VideoProcessor")[0],
                ram: ulong.Parse(SpecMonitor.GetHardwareInfo(GraphicsProcessingUnit.systemName, "AdapterRAM")[0]),
                driverVersion: SpecMonitor.GetHardwareInfo(GraphicsProcessingUnit.systemName, "DriverVersion")[0]
            );

            cpu.Print();

            Console.WriteLine("\n------\n");

            gpu.Print();

            Console.ReadLine();
        }
    }
}
