using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class CentralProcessingUnit : HardwareItem
    {
        static public readonly string systemName = "Win32_Processor";

        [JsonProperty("name")]
        public string Name { get; set;  }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("base_clock_speed")]
        public Frequency BaseClockSpeed { get; set; }

        [JsonProperty("number_of_cores")]
        public byte NumberOfCores { get; set; }

        [JsonProperty("number_of_logical_processors")]
        public byte NumberOfLogicalProcessors { get; set; }

        public CentralProcessingUnit(string name, string description, string manufacturer, ushort baseClockSpeed, byte numberOfCores, byte numberOfLogicalProcessors) 
        {
            Name = name;
            Description = description;
            Manufacturer = manufacturer;
            BaseClockSpeed = new Frequency(baseClockSpeed);
            NumberOfCores = numberOfCores;
            NumberOfLogicalProcessors = numberOfLogicalProcessors;
        }

        public CentralProcessingUnit() { }

        public override void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            string result = "Характеристики ЦПУ\n";
            
            result += $"Модель: {ProccessProperty(Name)}\n";
            result += $"Производитель: {ProccessProperty(Manufacturer)}\n";
            result += $"Описание: {ProccessProperty(Description)}\n";
            result += $"Базовая скорость: {BaseClockSpeed.GetGigahertz()} (гигагерц) ~ {BaseClockSpeed.Megahertz} (мегагерц)\n";
            result += $"Количество ядер: {NumberOfCores}\n";
            result += $"Количество потоков: {NumberOfLogicalProcessors}";
            
            return result;
        }
    }
}
