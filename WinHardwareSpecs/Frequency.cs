using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    public class Frequency
    {
        [JsonProperty("megahertz")]
        public int Megahertz { get; set; }

        [JsonProperty("gigahertz")]
        public double Gigahertz { get; set; }
        
        public double GetGigahertz(sbyte accuracy = 2) => accuracy != -1 ? Math.Round(Gigahertz, accuracy) : Gigahertz;

        public Frequency(ushort megahertz)
        {
            Megahertz = megahertz;
            Gigahertz = megahertz / 1000.0;
        }

        public Frequency()
        {
            Megahertz = 0;
            Gigahertz = 0;
        }
    }
}
