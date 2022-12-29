using System;
using System.Collections.Generic;
using System.Text;

namespace AbstarctFactoryDesignPattern
{
    public class LaptopFactory : DeviceFactory
    {
        public override Device GetDevice(string deviceType)
        {
            Device device = null;
            if (deviceType.ToLower() == "lenovo")
            {
                device = new Lenovo();
            }
            else if (deviceType.ToLower() == "dell")
            {
                device = new Dell();
            }
            return device;
        }
    }
}
