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
        private ulong _ram;
        private string _driverVersion;

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public ulong Ram { get { return _ram; } }
        public string DriverVersion { get { return _driverVersion; } }

        public GraphicsProcessingUnit(string name, string description, ulong ram, string driverVersion) 
        {
            _name = name;
            _description = description;
            _ram = ram;
            _driverVersion = driverVersion;
        }

        public void Print() 
        {
            const byte accuracy = 2;

            var sizeMb = Math.Round(_ram / Math.Pow(1024, 2), accuracy);
            var sizeGb = Math.Round(sizeMb / 1024, accuracy);

            Console.WriteLine($"Модель: {_name}");
            Console.WriteLine($"Описание: {_description}");
            Console.WriteLine($"Объем видеопамяти: {_ram} (байт) ~ {sizeMb} (мегабайт) ~ {sizeGb} (гигабайт)");
            Console.WriteLine($"Версия драйвера: {_driverVersion}");
        }
    }
}
