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
        private ulong _capacity;
        private ushort _speed;

        public string PartNumber { get { return _partNumber; } }
        public string Manufacturer { get { return _manufacturer; } }
        public ulong Capacity { get { return _capacity; } }
        public ushort Speed { get { return _speed; } }

        public PhysicalMemory(string partNumber, string manufacturer, ulong capacity, ushort speed)
        {
            _partNumber = partNumber;
            _manufacturer = manufacturer;   
            _capacity = capacity;
            _speed = speed;
        }

        public void Print()
        {
            const byte accuracy = 2;

            var capacityMb = _capacity / Math.Pow(1024, 2);
            var capacutyGb = capacityMb / 1024;

            Console.WriteLine($"Производитель: {_manufacturer}");
            Console.WriteLine($"Серийный номер: {_partNumber}");
            Console.WriteLine($"Объем: {_capacity} (байт) ~ {Math.Round(capacityMb, accuracy)} (мегабайт) ~ {Math.Round(capacutyGb, accuracy)} (гигабайт)");
            Console.WriteLine($"Скорость: {_speed} (мегагерц) ~ {Math.Round(_speed / 1000.0, accuracy)} (гигагерц)");
        }
    }
}
