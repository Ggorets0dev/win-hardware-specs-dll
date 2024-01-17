using Newtonsoft.Json;

namespace WinHardwareSpecs
{
    /// <summary>
    /// Функциональность компонента системы
    /// </summary>
    internal interface IHardwareItem
    {
        public void Print();
        public string ToJson(Formatting format);
        public string ToString();
    }
}
