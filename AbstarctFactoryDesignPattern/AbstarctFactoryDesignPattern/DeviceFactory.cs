using System;

namespace AbstarctFactoryDesignPattern
{
    public abstract class DeviceFactory
    {
        public abstract Device GetDevice(string deviceType);
        public static DeviceFactory createFactory(string factoryType)
        {
            if(factoryType.ToLower() == "mobile")
            {
                return new MobileFactory();
            }
            else if(factoryType.ToLower() == "laptop")
            {
                return new LaptopFactory();
            }
            return null;
        }
    }
}
