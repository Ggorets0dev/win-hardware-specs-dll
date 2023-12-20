using System;

namespace WinHardwareSpecs
{
    public class Capacity
    {
        private ulong _bytes;
        private double _megabytes;
        private double _gigabytes;

        public ulong GetBytes() => _bytes;
        public double GetMegabytes(sbyte accuracy = 2) => accuracy != -1 ? Math.Round(_megabytes, accuracy) : _megabytes;
        public double GetGigabytes(sbyte accuracy = 2) => accuracy != -1 ? Math.Round(_gigabytes, accuracy) : _gigabytes;

        public Capacity(ulong bytes) 
        {
            _bytes = bytes;
            _megabytes = bytes / Math.Pow(1024, 2);
            _gigabytes = _megabytes / 1024;
        }
    }
}
