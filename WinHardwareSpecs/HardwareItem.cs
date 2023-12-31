﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinHardwareSpecs
{
    public abstract class HardwareItem : IHardwareItem
    {
        protected readonly string _deafultProperty = "Не определено";

        protected string ProccessProperty(ref string property) => property != null ? property : _deafultProperty;

        public virtual void Print() => throw new NotImplementedException();
        
        public virtual string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
