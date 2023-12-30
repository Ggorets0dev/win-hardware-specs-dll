using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinHardwareSpecs
{
    public class PhysicalMemory : HardwareItem
    {
        static public readonly string systemName = "Win32_PhysicalMemory";

        private string _partNumber;
        private string _manufacturer;
        private Capacity _capacity;
        private Frequency _clockSpeed;

        [JsonProperty("part_number")]
        public string PartNumber => _partNumber;

        [JsonProperty("manufacturer")]
        public string Manufacturer => _manufacturer;

        [JsonProperty("capacity")]
        public Capacity Capacity => _capacity;

        [JsonProperty("clock_speed")]
        public Frequency ClockSpeed => _clockSpeed;

        public PhysicalMemory(string partNumber, string manufacturer, ulong bytesCapacity, ushort clockSpeed)
        {
            _partNumber = partNumber;
            _manufacturer = manufacturer;   
            _capacity = new Capacity(bytesCapacity);
            _clockSpeed = new Frequency(clockSpeed);
        }

        public override void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            string result = "Характеристики оперативной памяти\n";
            
            result += $"Серийный номер: {ProccessProperty(ref _partNumber)}\n";
            result += $"Объем: {_capacity.GetGigabytes(accuracy: 2)} (гигабайт) ~ {_capacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {_capacity.GetBytes()} (байт)\n";
            result += $"Скорость: {_clockSpeed.GetGigahertz()} (гигагерц) ~ {_clockSpeed.GetMegahertz()} (мегагерц)";
            
            return result;
        }
    }
}
