using System;
using System.Collections.Generic;
using System.Text;

namespace AbstarctFactoryDesignPattern
{
    public class Dell : Device
    {
        public string GetInfo()
        {
            string deviceType = "Laptop";
            string device = deviceType + "DELL";
            return device;
        }
    }
}
