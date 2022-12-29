using System;
using System.Collections.Generic;
using System.Text;

namespace AbstarctFactoryDesignPattern
{
    public class Lenovo : Device
    {
        public string GetInfo()
        {
            string deviceType = "Laptop";
            string device = deviceType + "Lenovo";
            return device;
        }
    }
}
