using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WinHardwareSpecs;

namespace FunctionalityTest
{
    /// <summary>
    /// Проверка основных компонентов DLL (получение и вывод спецификации)
    /// </summary>
    internal class Program
    {
        static void Main()
        {
            var specificationS = SpecMonitor.GetSpecification();

            var strJson = specificationS.ToJson(Formatting.Indented);

            Console.WriteLine(strJson);

            Console.WriteLine("\n");

            var specificationD = JsonConvert.DeserializeObject<Specification>(strJson);

            specificationD.Print();

            Console.ReadLine();
        }
    }
}
