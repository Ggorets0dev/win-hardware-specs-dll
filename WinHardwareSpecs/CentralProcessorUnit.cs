using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class CentralProcessorUnit : IHardwareItem
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

        public CentralProcessorUnit(string name, string description, string manufacturer, ushort baseClockSpeed, byte numberOfCores, byte numberOfLogicalProcessors) 
        { 
            _name = name;
            _description = description;
            _manufacturer = manufacturer;
            _baseClockSpeed = new Frequency(baseClockSpeed);
            _numberOfCores = numberOfCores;
            _numberOfLogicalProcessors = numberOfLogicalProcessors;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Модель: {_name}");
            Console.WriteLine($"Производитель: {_manufacturer}");
            Console.WriteLine($"Описание: {_description}");
            Console.WriteLine($"Базовая скорость: {_baseClockSpeed.GetMegahertz()} (мегагерц) ~ {_baseClockSpeed.GetGigahertz()} (гигагерц)");
            Console.WriteLine($"Количество ядер: {_numberOfCores}");
            Console.WriteLine($"Количество потоков: {_numberOfLogicalProcessors}");
        }
    }
}
