using System;
using System.Collections.Generic;
using System.Management;

namespace WinHardwareSpecs
{
    static public class SpecMonitor
    {
        static public List<string> GetHardwareInfo(string win32Class, string itemField)
        {
            var result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + win32Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[itemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
