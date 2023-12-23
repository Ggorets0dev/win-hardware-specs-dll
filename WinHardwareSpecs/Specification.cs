using Newtonsoft.Json;
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

        public virtual void Print() => Console.WriteLine(ToString());

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

            string result = UnitsToString(_cpuObjects.Cast<IHardwareItem>().ToList());

            result += "\n\n";

            result += UnitsToString(_gpuObjects.Cast<IHardwareItem>().ToList());

            result += "\n\n";

            result += UnitsToString(_ramOjbects.Cast<IHardwareItem>().ToList());

            result += "\n\n";

            result += UnitsToString(_osObjects.Cast<IHardwareItem>().ToList());

            return result;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
