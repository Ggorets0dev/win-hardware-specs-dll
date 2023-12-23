using Newtonsoft.Json;

namespace WinHardwareSpecs
{
    internal interface IHardwareItem
    {
        public void Print();
        public string ToJson();
        public string ToString();
    }
}
