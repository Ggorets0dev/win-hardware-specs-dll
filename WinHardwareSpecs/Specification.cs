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
        [JsonProperty("cpu_units")]
        public List<CentralProcessingUnit> CpuUnits { get; set; }

        [JsonProperty("gpu_units")]
        public List<GraphicsProcessingUnit> GpuUnits { get; set; }

        [JsonProperty("ram_units")]
        public List<PhysicalMemory> RamUnits { get; set; }

        [JsonProperty("os_units")]
        public List<OperatingSystem> OsUnits { get; set; }

        public Specification(List<CentralProcessingUnit> cpuObjects, List<GraphicsProcessingUnit> gpuObjects, List<PhysicalMemory> ramOjbects, List<OperatingSystem> osObjects)
        {
            CpuUnits = cpuObjects;
            GpuUnits = gpuObjects;
            RamUnits = ramOjbects;
            OsUnits = osObjects;
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
            string gpuUnits = UnitsToString(GpuUnits.Cast<IHardwareItem>().ToList());
            string cpuUnits = UnitsToString(CpuUnits.Cast<IHardwareItem>().ToList());
            string ramUnits = UnitsToString(RamUnits.Cast<IHardwareItem>().ToList());
            string osUnits = UnitsToString(OsUnits.Cast<IHardwareItem>().ToList());

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
