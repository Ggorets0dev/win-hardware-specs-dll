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

        public string Name {  get { return _name; } }
        public string Description { get { return _description; } }
        public string Manufacturer { get { return _manufacturer; } }

        public CentralProcessorUnit(string name, string description, string manufacturer) 
        { 
            _name = name;
            _description = description;
            _manufacturer = manufacturer;
        }

        public void Print()
        {
            Console.WriteLine($"Модель: {_name}");
            Console.WriteLine($"Производитель: {_manufacturer}");
            Console.WriteLine($"Описание: {_description}");
        }
    }
}
