using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardwareSpecs
{
    /// <summary>
    /// Частота любого компонента в мегагерцах, гигагерцах
    /// </summary>
    public class Frequency
    {
        [JsonProperty("megahertz")]
        public int Megahertz { get; set; }

        [JsonProperty("gigahertz")]
        public double Gigahertz { get; set; }

        /// <summary>
        /// Получить значение в гигагерцах с возможным округлением
        /// </summary>
        /// <param name="accuracy">Количество знаков после запятой (-1 для отмены округления)</param>
        /// <returns>Округленное значение в гигагерцах</returns>
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
