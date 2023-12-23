using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class GraphicsProcessingUnit : IHardwareItem
    {
        static public readonly string systemName = "Win32_VideoController";

        private string _name;
        private string _description;
        private Capacity _memoryCapacity;
        private string _driverVersion;

        [JsonProperty("name")]
        public string Name => _name;

        [JsonProperty("description")]
        public string Description => _description;

        [JsonProperty("memory_capacity")]
        public Capacity MemoryCapacity => _memoryCapacity;

        [JsonProperty("driver_version")]
        public string DriverVersion => _driverVersion;

        public GraphicsProcessingUnit(string name, string description, ulong bytesMemoryCapacity, string driverVersion) 
        {
            _name = name;
            _description = description;
            _memoryCapacity = new Capacity(bytesMemoryCapacity);
            _driverVersion = driverVersion;
        }

        public virtual void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            string result = "Характеристики ГПУ\n";
            result += $"Модель: {_name}\n";
            result += $"Описание: {_description}\n";
            result += $"Объем видеопамяти: {_memoryCapacity.GetBytes()} (байт) ~ {_memoryCapacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {_memoryCapacity.GetGigabytes(accuracy: 2)} (гигабайт)\n";
            result += $"Версия драйвера: {_driverVersion}";
            return result;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
