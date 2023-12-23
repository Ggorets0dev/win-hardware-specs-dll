﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class Specification : IHardwareItem
    {
        private List<CentralProcessingUnit> _cpuObjects;
        private List<GraphicsProcessingUnit> _gpuObjects;
        private List<PhysicalMemory> _ramOjbects;
        private List<OperatingSystem> _osObjects;

        [JsonProperty("cpu_units")]
        public List<CentralProcessingUnit> CpuUnits => _cpuObjects;

        [JsonProperty("gpu_units")]
        public List<GraphicsProcessingUnit> GpuUnits => _gpuObjects;

        [JsonProperty("ram_units")]
        public List<PhysicalMemory> RamUnits => _ramOjbects;

        [JsonProperty("os_units")]
        public List<OperatingSystem> OsUnits => _osObjects;

        public Specification(List<CentralProcessingUnit> cpuObjects, List<GraphicsProcessingUnit> gpuObjects, List<PhysicalMemory> ramOjbects, List<OperatingSystem> osObjects)
        {
            _cpuObjects = cpuObjects;
            _gpuObjects = gpuObjects;
            _ramOjbects = ramOjbects;
            _osObjects = osObjects;
        }

        public virtual void Print()
        {
            void PrintUnits(List<IHardwareItem> units)
            {
                foreach (var unit in units)
                {
                    unit.Print();
                    Console.WriteLine("\n----------\n");
                }
            }

            PrintUnits(_cpuObjects.Cast<IHardwareItem>().ToList());
            PrintUnits(_gpuObjects.Cast<IHardwareItem>().ToList());
            PrintUnits(_ramOjbects.Cast<IHardwareItem>().ToList());
            PrintUnits(_osObjects.Cast<IHardwareItem>().ToList());
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
