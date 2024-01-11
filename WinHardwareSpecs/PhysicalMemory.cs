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

        [JsonProperty("part_number")]
        public string PartNumber { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("capacity")]
        public Capacity Capacity { get; set; }

        [JsonProperty("clock_speed")]
        public Frequency ClockSpeed { get; set; }

        public PhysicalMemory(string partNumber, string manufacturer, ulong bytesCapacity, ushort clockSpeed)
        {
            PartNumber = partNumber;
            Manufacturer = manufacturer;
            Capacity = new Capacity(bytesCapacity);
            ClockSpeed = new Frequency(clockSpeed);
        }

        public PhysicalMemory() { }

        public override string ToString()
        {
            string result = "Характеристики оперативной памяти\n";
            
            result += $"Серийный номер: {ProccessProperty(PartNumber)}\n";
            result += $"Объем: {Capacity.GetGigabytes(accuracy: 2)} (гигабайт) ~ {Capacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {Capacity.Bytes} (байт)\n";
            result += $"Скорость: {ClockSpeed.GetGigahertz()} (гигагерц) ~ {ClockSpeed.Megahertz} (мегагерц)";
            
            return result;
        }
    }
}
