using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class GraphicsProcessingUnit
    {
        static public readonly string systemName = "Win32_VideoController";

        private string _name;
        private string _description;
        private string _ram;
        private string _driverVersion;

        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public string Ram { get { return _ram; } }
        public string DriverVersion { get { return _driverVersion; } }

        public GraphicsProcessingUnit(string name, string description, string ram, string driverVersion) 
        {
            _name = name;
            _description = description;
            _ram = ram;
            _driverVersion = driverVersion;
        }

        public void Print() 
        {
            Console.WriteLine($"Модель: {_name}");
            Console.WriteLine($"Описание: {_description}");
            Console.WriteLine($"Объем видеопамяти: {_ram}");
            Console.WriteLine($"Версия драйвера: {_driverVersion}");
        }
    }
}
