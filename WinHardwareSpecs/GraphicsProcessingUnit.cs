using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class GraphicsProcessingUnit : HardwareItem
    {
        static public readonly string systemName = "Win32_VideoController";

        [JsonProperty("name")]
        public string Name { get; set; }

    [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("memory_capacity")]
        public Capacity MemoryCapacity { get; set; }

        [JsonProperty("driver_version")]
        public string DriverVersion { get; set; }

        public GraphicsProcessingUnit(string name, string description, ulong bytesMemoryCapacity, string driverVersion) 
        {
            Name = name;
            Description = description;
            MemoryCapacity = new Capacity(bytesMemoryCapacity);
            DriverVersion = driverVersion;
        }

        public GraphicsProcessingUnit() { }

        public override string ToString()
        {
            string result = "Характеристики ГПУ\n";
            
            result += $"Модель: {ProccessProperty(Name)}\n";
            result += $"Описание: {ProccessProperty(Description)}\n";
            result += $"Объем видеопамяти: {MemoryCapacity.GetGigabytes(accuracy: 2)} (гигабайт) ~ {MemoryCapacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {MemoryCapacity.Bytes} (байт)\n";
            result += $"Версия драйвера: {ProccessProperty(DriverVersion)}";
            
            return result;
        }
    }
}
