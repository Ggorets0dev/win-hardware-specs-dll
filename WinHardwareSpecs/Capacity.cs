using System;
using Newtonsoft.Json;

namespace WinHardwareSpecs
{
    /// <summary>
    /// Размер любого компонента в байтах, мегабайтах, гигабайтах
    /// </summary>
    public class Capacity
    {
        [JsonProperty("bytes")]
        public ulong Bytes { get; set; }

        [JsonProperty("megabytes")]
        public double Megabytes { get; set; }

        [JsonProperty("gigabytes")]
        public double Gigabytes { get; set; }

        /// <summary>
        /// Получить значение в мегабайтах с возможным округлением
        /// </summary>
        /// <param name="accuracy">Количество знаков после запятой (-1 для отмены округления)</param>
        /// <returns>Округленное значение в мегабайтах</returns>
        public double GetMegabytes(sbyte accuracy = 2) => accuracy != -1 ? Math.Round(Megabytes, accuracy) : Megabytes;

        /// <summary>
        /// Получить значение в гигабайтах с возможным округлением
        /// </summary>
        /// <param name="accuracy">Количество знаков после запятой (-1 для отмены округления)</param>
        /// <returns>Округленное значение в гигабайтах</returns>
        public double GetGigabytes(sbyte accuracy = 2) => accuracy != -1 ? Math.Round(Gigabytes, accuracy) : Gigabytes;

        public Capacity(ulong bytes) 
        {
            Bytes = bytes;
            Megabytes = bytes / Math.Pow(1024, 2);
            Gigabytes = Megabytes / 1024.0;
        }

        public Capacity()
        {
            Bytes = 0;
            Megabytes = 0;
            Gigabytes = 0;
        }
    }
}
