using System;
using System.Linq;
using Xunit;
using WinHardwareSpecs;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AllUnitTests
{
    /// <summary>
    /// Проверка обнаружения устройств в ПК
    /// </summary>
    public class GetHardwareItemsUnitTest
    {
        [Fact]
        public void CpuObjectsFound()
        {
            var listCpu = SpecMonitor.GetCentralProcessingUnits();
            Assert.True(listCpu.Count > 0);
        }

        [Fact]
        public void GpuObjectsFound()
        {
            var listGpu = SpecMonitor.GetGraphicalProcessingUnits();
            Assert.True(listGpu.Count > 0);
        }

        [Fact]
        public void RamObjectsFound()
        {
            var listRam = SpecMonitor.GetPhysicalMemory();
            Assert.True(listRam.Count > 0);
        }

        [Fact]
        public void OsObjectsFound()
        {
            var listOs = SpecMonitor.GetOperatingSystems();
            Assert.True(listOs.Count > 0);
        }
    }

    /// <summary>
    /// Проверка получения характеристики устройств
    /// </summary>
    public class CheckHardwareItemsUnitTest
    {
        [Fact]
        public void CpuObjectsContains()
        {
            var listCpu = SpecMonitor.GetCentralProcessingUnits();

            foreach (var cpu in listCpu) 
            {
                Assert.True(cpu.ToString().Length > 0);
                Assert.True(cpu.ToJson().Length > 0);
            }
        }

        [Fact]
        public void GpuObjectsContains()
        {
            var listGpu = SpecMonitor.GetGraphicalProcessingUnits();
            
            foreach (var gpu in listGpu)
            {
                Assert.True(gpu.ToString().Length > 0);
                Assert.True(gpu.ToJson().Length > 0);
            }
        }

        [Fact]
        public void RamObjectsContains()
        {
            var listRam = SpecMonitor.GetPhysicalMemory();
            
            foreach (var ram in listRam)
            {
                Assert.True(ram.ToString().Length > 0);
                Assert.True(ram.ToJson().Length > 0);
            }
        }

        [Fact]
        public void OsObjectsContains()
        {
            var listOs = SpecMonitor.GetOperatingSystems();
            
            foreach (var os in listOs)
            {
                Assert.True(os.ToString().Length > 0);
                Assert.True(os.ToJson().Length > 0);
            }
        }
    }

    /// <summary>
    /// Проверка получения полной спецификации ПК
    /// </summary>
    public class SpecificationUnitTest
    {
        [Fact]
        public void SpecificationFoundAndContains() 
        {
            var specification = SpecMonitor.GetSpecification();
            
            Assert.True(specification.ToString().Length > 0);
            Assert.True(specification.ToJson().Length > 0);
        }
    }
}
