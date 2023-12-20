using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class OperatingSystem : IHardwareItem
    {
        static public readonly string systemName = "Win32_OperatingSystem";

        private string _name;
        private string _version;
        private string _serialNumber;

        public string Name { get { return _name; } }
        public string Version { get { return _version; } }
        public string SerialNumber { get { return _serialNumber; } }

        public OperatingSystem(string name, string version, string serialNumber)
        {
            _name = name;
            _version = version;
            _serialNumber = serialNumber;
        }

        public void Print()
        {
            Console.WriteLine($"Наименование: {_name}");
            Console.WriteLine($"Версия: {_version}");
            Console.WriteLine($"Серийный номер: {_serialNumber}");
        }
    }
}
