using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletondesign
{
    public sealed class Singleton
    {
        //private static Singleton instance;
        private static int counter = 0;
        private static readonly object obj = new object();
        private Singleton()
        {
            Console.WriteLine(counter);
            counter++;
        }

        //Eager loading of object


        //private static readonly Singleton instance = new Singleton();
        //public static Singleton Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        //Lazy loading of object

        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(()=> new Singleton());
        public static Singleton Instance
        {
            get
            {
                return instance.Value;
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine("This is printinfo method in singleton class");
        }
    }
}
