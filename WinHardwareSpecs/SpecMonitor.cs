using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management;

namespace WinHardwareSpecs
{
    static public class SpecMonitor
    {
        public class Specification
        {
            public List<CentralProcessorUnit> cpuObjects;
            public List<GraphicsProcessingUnit> gpuObjects;
            public List<PhysicalMemory> ramOjbects;
            public List<OperatingSystem> osObjects;

            public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        static private List<ManagementObject> GetManagementObjects(string win32Class)
        {
            var objects = new List<ManagementObject>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {win32Class}");

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    objects.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return objects;
        }

        static private string ProcessSpec(ManagementObject obj, string spec) => obj[spec].ToString().Trim();

        static public Specification GetSpecification()
        {
            return new Specification
            {
                cpuObjects = GetCentralProcessingUnits(),
                gpuObjects = GetGraphicalProcessingUnits(),
                ramOjbects = GetPhysicalMemory(),
                osObjects = GetOperatingSystems(),
            };
        }

        static public List<string> GetHardwareInfo(string win32Class, string itemField)
        {
            var specs = new List<string>();

            try
            {
                foreach (ManagementObject obj in GetManagementObjects(win32Class))
                {
                    specs.Add(obj[itemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return specs;
        }
    
        static public List<OperatingSystem> GetOperatingSystems()
        {
            var operatingSystems = new List<OperatingSystem>();

            try
            {
                foreach (ManagementObject currentManagementObject in GetManagementObjects(OperatingSystem.systemName))
                {
                    var osObject = new OperatingSystem(
                        name: ProcessSpec(currentManagementObject, "Caption"),
                        version: ProcessSpec(currentManagementObject, "Version"),
                        serialNumber: ProcessSpec(currentManagementObject, "SerialNumber")
                    );

                    operatingSystems.Add(osObject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return operatingSystems;
        }

        static public List<PhysicalMemory> GetPhysicalMemory() 
        {
            var physicalMemory = new List<PhysicalMemory>();

            try
            {
                foreach (ManagementObject currentManagementObject in GetManagementObjects(PhysicalMemory.systemName))
                {
                    var physicalMemoryObject = new PhysicalMemory(
                        partNumber: ProcessSpec(currentManagementObject, "PartNumber"),
                        manufacturer: ProcessSpec(currentManagementObject, "Manufacturer"),
                        bytesCapacity: ulong.Parse(ProcessSpec(currentManagementObject, "Capacity")),
                        clockSpeed: ushort.Parse(ProcessSpec(currentManagementObject, "Speed"))
                    );

                    physicalMemory.Add(physicalMemoryObject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return physicalMemory;
        }

        static public List<GraphicsProcessingUnit> GetGraphicalProcessingUnits()
        {
            var graphicsProcessingUnits = new List<GraphicsProcessingUnit>();

            try
            {
                foreach (ManagementObject currentManagementObject in GetManagementObjects(GraphicsProcessingUnit.systemName))
                {
                    var graphicalProcessingUnitObject = new GraphicsProcessingUnit(
                        name: ProcessSpec(currentManagementObject, "Name"),
                        description: ProcessSpec(currentManagementObject, "VideoProcessor"),
                        bytesMemoryCapacity: ulong.Parse(ProcessSpec(currentManagementObject, "AdapterRAM")),
                        driverVersion: ProcessSpec(currentManagementObject, "DriverVersion")
                    );

                    graphicsProcessingUnits.Add(graphicalProcessingUnitObject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return graphicsProcessingUnits;
        }

        static public List<CentralProcessorUnit> GetCentralProcessingUnits()
        {
            var centralProcessingUnits = new List<CentralProcessorUnit>();

            try
            {
                foreach (ManagementObject currentManagementObject in GetManagementObjects(CentralProcessorUnit.systemName))
                {
                    var centralProcessingUnitObject = new CentralProcessorUnit(
                        name: ProcessSpec(currentManagementObject, "Name"),
                        description: ProcessSpec(currentManagementObject, "Description"),
                        baseClockSpeed: ushort.Parse(ProcessSpec(currentManagementObject, "CurrentClockSpeed")),
                        manufacturer: ProcessSpec(currentManagementObject, "Manufacturer"),
                        numberOfCores: byte.Parse(ProcessSpec(currentManagementObject, "NumberOfCores")),
                        numberOfLogicalProcessors: byte.Parse(ProcessSpec(currentManagementObject, "NumberOfLogicalProcessors"))
                    );

                    centralProcessingUnits.Add(centralProcessingUnitObject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return centralProcessingUnits;
        }
    }
}
