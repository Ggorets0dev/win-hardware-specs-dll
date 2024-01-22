using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinHardwareSpecs
{
    /// <summary>
    /// Характеристики ОС
    /// </summary>
    public class OperatingSystem : HardwareItem
    {
        static public readonly string systemName = "Win32_OperatingSystem";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }

        public OperatingSystem(string name, string version, string serialNumber)
        {
            Name = name;
            Version = version;
            SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            string result = "Характеристики операционной системы\n";
            
            result += $"Наименование: {ProccessProperty(Name)}\n";
            result += $"Версия: {ProccessProperty(Version)}\n";
            result += $"Серийный номер: {ProccessProperty(SerialNumber)}";
            
            return result;
        }
    }
}
