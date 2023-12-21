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

        public string Name => _name;
        public string Description => _description;
        public Capacity MemoryCapacity => _memoryCapacity;
        public string DriverVersion => _driverVersion;

        public GraphicsProcessingUnit(string name, string description, ulong bytesMemoryCapacity, string driverVersion) 
        {
            _name = name;
            _description = description;
            _memoryCapacity = new Capacity(bytesMemoryCapacity);
            _driverVersion = driverVersion;
        }

        public virtual void Print() 
        {
            Console.WriteLine($"Модель: {_name}");
            Console.WriteLine($"Описание: {_description}");
            Console.WriteLine($"Объем видеопамяти: {_memoryCapacity.GetBytes()} (байт) ~ {_memoryCapacity.GetMegabytes(accuracy: 2)} (мегабайт) ~ {_memoryCapacity.GetGigabytes(accuracy: 2)} (гигабайт)");
            Console.WriteLine($"Версия драйвера: {_driverVersion}");
        }
    }
}
