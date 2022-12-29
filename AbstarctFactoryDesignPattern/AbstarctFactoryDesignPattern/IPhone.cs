using System;
using System.Collections.Generic;
using System.Text;

namespace AbstarctFactoryDesignPattern
{
    public class IPhone : Device
    {
        public string GetInfo()
        {
            string deviceType = "Mobile";
            string device = deviceType+"IPhone";
            return device;
        }
    }
}
