using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinHardwareSpecs
{
    public abstract class HardwareItem : IHardwareItem
    {
        protected readonly string _deafultProperty = "Не определено";

        protected string ProccessProperty(string property) => property != null ? property : _deafultProperty;

        public virtual void Print() => Console.WriteLine(ToString());

        public virtual string ToJson(Formatting format = Formatting.None) => JsonConvert.SerializeObject(this, format);
    }
}
