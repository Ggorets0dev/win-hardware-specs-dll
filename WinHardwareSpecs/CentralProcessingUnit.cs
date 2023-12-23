using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class CentralProcessingUnit : IHardwareItem
    {
        static public readonly string systemName = "Win32_Processor";

        private string _name;
        private string _description;
        private string _manufacturer;
        private Frequency _baseClockSpeed;
        private byte _numberOfCores;
        private byte _numberOfLogicalProcessors;

        public string Name => _name;
        public string Description => _description;
        public string Manufacturer => _manufacturer;
        public Frequency BaseClockSpeed => _baseClockSpeed;

        public CentralProcessingUnit(string name, string description, string manufacturer, ushort baseClockSpeed, byte numberOfCores, byte numberOfLogicalProcessors) 
        { 
            _name = name;
            _description = description;
            _manufacturer = manufacturer;
            _baseClockSpeed = new Frequency(baseClockSpeed);
            _numberOfCores = numberOfCores;
            _numberOfLogicalProcessors = numberOfLogicalProcessors;
        }

        public virtual void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            string result = "Характеристики ЦПУ\n";
           result += $"Модель: {_name}\n";
           result += $"Производитель: {_manufacturer}\n";
           result += $"Описание: {_description}\n";
           result += $"Базовая скорость: {_baseClockSpeed.GetMegahertz()} (мегагерц) ~ {_baseClockSpeed.GetGigahertz()} (гигагерц)\n";
           result += $"Количество ядер: {_numberOfCores}\n";
           result += $"Количество потоков: {_numberOfLogicalProcessors}";
            return result;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
