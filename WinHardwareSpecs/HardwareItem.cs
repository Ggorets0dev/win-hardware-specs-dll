using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinHardwareSpecs
{
    /// <summary>
    /// Базовый класс компонента устройства
    /// </summary>
    public abstract class HardwareItem : IHardwareItem
    {
        /// <summary>
        /// Значение для замены в случае отсутствия характеристики
        /// </summary>
        protected readonly string _deafultProperty = "Не определено";

        /// <summary>
        /// Обработка характеристики для вывода
        /// </summary>
        /// <param name="property">Значение характеристики</param>
        /// <returns></returns>
        protected string ProccessProperty(string property) => property != null ? property : _deafultProperty;

        /// <summary>
        /// Вывод характеристик устройства в CLI
        /// </summary>
        public virtual void Print() => Console.WriteLine(ToString());

        /// <summary>
        /// Перевод характеристик устройства в JSON формат
        /// </summary>
        public virtual string ToJson(Formatting format = Formatting.None) => JsonConvert.SerializeObject(this, format);
    }
}
