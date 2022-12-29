using System;
using System.Collections.Generic;
using System.Text;

namespace AbstarctFactoryDesignPattern
{
    public class Samsung : Device
    {
        public string GetInfo()
        {
            string deviceType = "Mobile";
            string device = deviceType + "Samsung";
            return device;
        }
    }
}
