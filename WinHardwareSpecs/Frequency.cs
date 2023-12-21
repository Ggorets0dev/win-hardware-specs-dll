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
        private ushort _megahertz;

        [JsonProperty("gigahertz")]
        private double _gigahertz;
        
        public ushort GetMegahertz() => _megahertz;
        public double GetGigahertz(sbyte accuracy = 2) => accuracy != -1 ? Math.Round(_gigahertz, accuracy) : _gigahertz;

        public Frequency(ushort megahertz)
        {
            _megahertz = megahertz;
            _gigahertz = megahertz / 1000.0;
        }
    }
}
