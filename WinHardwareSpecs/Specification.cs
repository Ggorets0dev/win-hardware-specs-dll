using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class Specification : HardwareItem
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

        public override void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            string UnitsToString(List<IHardwareItem> units)
            {
                string result = "";

                int currentUnitInx = 0;
                int unitsCount = units.Count();

                while (currentUnitInx < unitsCount)
                {
                    result += units[currentUnitInx].ToString();

                    if (currentUnitInx != unitsCount - 1) 
                        result += "\n----------\n";

                    currentUnitInx += 1;
                }

                return result;
            }

            string result = string.Empty;
            string gpuUnits = UnitsToString(_gpuObjects.Cast<IHardwareItem>().ToList());
            string cpuUnits = UnitsToString(_cpuObjects.Cast<IHardwareItem>().ToList());
            string ramUnits = UnitsToString(_ramOjbects.Cast<IHardwareItem>().ToList());
            string osUnits = UnitsToString(_osObjects.Cast<IHardwareItem>().ToList());

            if (cpuUnits.Length > 0)
                result += (cpuUnits + "\n\n");

            if (gpuUnits.Length > 0)
                result += (gpuUnits + "\n\n");

            if (ramUnits.Length > 0)
                result += (ramUnits + "\n\n");

            if (osUnits.Length > 0)
                result += osUnits;

            return result;
        }
    }
}
