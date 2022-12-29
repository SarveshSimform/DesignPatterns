using System;
using System.Collections.Generic;
using System.Text;

namespace AbstarctFactoryDesignPattern
{
    public class MobileFactory : DeviceFactory
    {
        public override Device GetDevice(string deviceType)
        {
            Device device = null;
            if (deviceType.ToLower() == "iphone")
            {
                device = new IPhone();
            }
            else if (deviceType.ToLower() == "samsung")
            {
                device = new Samsung();
            }
            return device;
        }
    }
}
