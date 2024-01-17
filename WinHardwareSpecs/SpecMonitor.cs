using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management;

namespace WinHardwareSpecs
{
    /// <summary>
    /// Инструмент для получения характеристик устройства
    /// </summary>
    static public class SpecMonitor
    {
        static private List<ManagementObject> GetManagementObjects(string win32Class)
        {
            var objects = new List<ManagementObject>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {win32Class}");

            foreach (ManagementObject obj in searcher.Get())
                objects.Add(obj);

            return objects;
        }

        static private string ProcessSpec(ManagementObject obj, string spec)
        {
            var characteristic = obj[spec];

            if (characteristic != null) 
                return characteristic.ToString().Trim();

            else
                return null;
        }

        /// <summary>
        /// Получить спецификацию данному устройству
        /// </summary>
        /// <returns>Спецификация</returns>
        static public Specification GetSpecification()
        {
            return new Specification(
                cpuObjects: GetCentralProcessingUnits(),
                gpuObjects: GetGraphicalProcessingUnits(),
                ramOjbects: GetPhysicalMemory(),
                osObjects: GetOperatingSystems()
            );
        }

        /// <summary>
        /// Получить определенную характеристику определенного компонента системы
        /// </summary>
        /// <param name="win32Class">Компонент</param>
        /// <param name="itemField">ХарактеристикаН</param>
        /// <returns>Характеристики всех компонентов данного вида</returns>
        static public List<string> GetHardwareInfo(string win32Class, string itemField)
        {
            var specs = new List<string>();

            foreach (ManagementObject obj in GetManagementObjects(win32Class))
                specs.Add(obj[itemField].ToString().Trim());

            return specs;
        }
    
        /// <summary>
        /// Получить объекты операционных систем устройства
        /// </summary>
        /// <returns>Операционные системы</returns>
        static public List<OperatingSystem> GetOperatingSystems()
        {
            var operatingSystems = new List<OperatingSystem>();


            foreach (ManagementObject currentManagementObject in GetManagementObjects(OperatingSystem.systemName))
            {
                var osObject = new OperatingSystem(
                        name: ProcessSpec(currentManagementObject, "Caption"),
                        version: ProcessSpec(currentManagementObject, "Version"),
                        serialNumber: ProcessSpec(currentManagementObject, "SerialNumber")
                    );

                operatingSystems.Add(osObject);
            }


            return operatingSystems;
        }

        /// <summary>
        /// Получить объекты ОЗУ устройства
        /// </summary>
        /// <returns>Объекты ОЗУ</returns>
        static public List<PhysicalMemory> GetPhysicalMemory() 
        {
            var physicalMemory = new List<PhysicalMemory>();

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

            return physicalMemory;
        }

        /// <summary>
        /// Получить объекты ГПУ устройства
        /// </summary>
        /// <returns>Объекты ГПУ</returns>
        static public List<GraphicsProcessingUnit> GetGraphicalProcessingUnits()
        {
            var graphicsProcessingUnits = new List<GraphicsProcessingUnit>();

            foreach (ManagementObject currentManagementObject in GetManagementObjects(GraphicsProcessingUnit.systemName))
            {
                string name = ProcessSpec(currentManagementObject, "Name");
                string description = ProcessSpec(currentManagementObject, "VideoProcessor");
                string driverVersion = ProcessSpec(currentManagementObject, "DriverVersion");

                ulong bytesMemoryCapacity;
                string bytesMemoryCapacityBuffer = ProcessSpec(currentManagementObject, "AdapterRAM");
                    
                ulong.TryParse(bytesMemoryCapacityBuffer, out bytesMemoryCapacity);

                var graphicalProcessingUnitObject = new GraphicsProcessingUnit(
                        name: name,
                        description: description,
                        bytesMemoryCapacity: bytesMemoryCapacity,
                        driverVersion: driverVersion
                    );

                graphicsProcessingUnits.Add(graphicalProcessingUnitObject);
            }

            return graphicsProcessingUnits;
        }

        /// <summary>
        /// Получить объекты ЦПУ устройства
        /// </summary>
        /// <returns>Объекты ЦПУ</returns>
        static public List<CentralProcessingUnit> GetCentralProcessingUnits()
        {
            var centralProcessingUnits = new List<CentralProcessingUnit>();

             foreach (ManagementObject currentManagementObject in GetManagementObjects(CentralProcessingUnit.systemName))
             {
                var centralProcessingUnitObject = new CentralProcessingUnit(
                        name: ProcessSpec(currentManagementObject, "Name"),
                        description: ProcessSpec(currentManagementObject, "Description"),
                        baseClockSpeed: ushort.Parse(ProcessSpec(currentManagementObject, "CurrentClockSpeed")),
                        manufacturer: ProcessSpec(currentManagementObject, "Manufacturer"),
                        numberOfCores: byte.Parse(ProcessSpec(currentManagementObject, "NumberOfCores")),
                        numberOfLogicalProcessors: byte.Parse(ProcessSpec(currentManagementObject, "NumberOfLogicalProcessors"))
                    );

                centralProcessingUnits.Add(centralProcessingUnitObject);
             }

            return centralProcessingUnits;
        }
    }
}
