using Newtonsoft.Json;

namespace WinHardwareSpecs
{
    internal interface IHardwareItem
    {
        public void Print();
        public string ToJson(Formatting format);
        public string ToString();
    }
}
