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
        private ushort _baseClockSpeed;
        private byte _numberOfCores;
        private byte _numberOfLogicalProcessors;

        public string Name {  get { return _name; } }
        public string Description { get { return _description; } }
        public string Manufacturer { get { return _manufacturer; } }
        public ushort BaseClockSpeed {  get { return _baseClockSpeed; } }

        public CentralProcessorUnit(string name, string description, string manufacturer, ushort baseClockSpeed, byte numberOfCores, byte numberOfLogicalProcessors) 
        { 
            _name = name;
            _description = description;
            _manufacturer = manufacturer;
            _baseClockSpeed = baseClockSpeed;
            _numberOfCores = numberOfCores;
            _numberOfLogicalProcessors = numberOfLogicalProcessors;
        }

        public void Print()
        {
            Console.WriteLine($"Модель: {_name}");
            Console.WriteLine($"Производитель: {_manufacturer}");
            Console.WriteLine($"Описание: {_description}");
            Console.WriteLine($"Базовая скорость: {_baseClockSpeed} (герц) ~ {Math.Round(_baseClockSpeed / 1000.0, 2)} (гигагерц)");
            Console.WriteLine($"Количество ядер: {_numberOfCores}");
            Console.WriteLine($"Количество потоков: {_numberOfLogicalProcessors}");
        }
    }
}
