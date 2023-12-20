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
        private ushort _speed;

        public string PartNumber => _partNumber;
        public string Manufacturer => _manufacturer;
        public Capacity Capacity => _capacity;
        public ushort Speed => _speed;

        public PhysicalMemory(string partNumber, string manufacturer, ulong bytesCapacity, ushort speed)
        {
            _partNumber = partNumber;
            _manufacturer = manufacturer;   
            _capacity = new Capacity(bytesCapacity);
            _speed = speed;
        }

        public void Print()
        {
            Console.WriteLine($"Производитель: {_manufacturer}");
            Console.WriteLine($"Серийный номер: {_partNumber}");
            Console.WriteLine($"Объем: {_capacity.GetBytes()} (байт) ~ {_capacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {_capacity.GetGigabytes(accuracy: 2)} (гигабайт)");
            Console.WriteLine($"Скорость: {_speed} (мегагерц) ~ {Math.Round(_speed / 1000.0, 2)} (гигагерц)");
        }
    }
}
