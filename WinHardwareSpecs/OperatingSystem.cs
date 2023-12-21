﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WinHardwareSpecs
{
    public class OperatingSystem : IHardwareItem
    {
        static public readonly string systemName = "Win32_OperatingSystem";

        private string _name;
        private string _version;
        private string _serialNumber;

        [JsonProperty("name")]
        public string Name => _name;

        [JsonProperty("version")]
        public string Version => _version;

        [JsonProperty("serial_number")]
        public string SerialNumber => _serialNumber;

        public OperatingSystem(string name, string version, string serialNumber)
        {
            _name = name;
            _version = version;
            _serialNumber = serialNumber;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Наименование: {_name}");
            Console.WriteLine($"Версия: {_version}");
            Console.WriteLine($"Серийный номер: {_serialNumber}");
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
