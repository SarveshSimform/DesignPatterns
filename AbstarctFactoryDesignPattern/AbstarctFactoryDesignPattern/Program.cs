using System;

namespace AbstarctFactoryDesignPattern
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Factory type that you want!");
            var factoryType = Console.ReadLine();
            var deviceFactory = DeviceFactory.createFactory(factoryType);
            if (deviceFactory != null)
            {
                Console.WriteLine($"Enter Device Name of {factoryType} for getting info!");
                var deviceName = Console.ReadLine();
                var device = deviceFactory?.GetDevice(deviceName);
                if (device != null)
                {
                    string result = device?.GetInfo();
                    Console.WriteLine($"Your Factory : {factoryType}");
                    Console.WriteLine($"Your Device : {deviceName}");
                    Console.WriteLine($"Device Info : {result}");
                }
                else
                {
                    Console.WriteLine("Invalid Device Name!!!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Factory Name!!!");
            }
        }
    }
}
