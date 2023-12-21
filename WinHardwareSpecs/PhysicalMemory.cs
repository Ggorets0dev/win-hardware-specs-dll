using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class PhysicalMemory : IHardwareItem
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

        public virtual void Print()
        {
            Console.WriteLine($"Производитель: {_manufacturer}");
            Console.WriteLine($"Серийный номер: {_partNumber}");
            Console.WriteLine($"Объем: {_capacity.GetBytes()} (байт) ~ {_capacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {_capacity.GetGigabytes(accuracy: 2)} (гигабайт)");
            Console.WriteLine($"Скорость: {_clockSpeed.GetMegahertz()} (мегагерц) ~ {_clockSpeed.GetGigahertz()} (гигагерц)");
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
