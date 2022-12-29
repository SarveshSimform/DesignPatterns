using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletondesign
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parallel.Invoke(()=>obj1Info(),()=>obj2Info());
            LogInformation();
            Console.ReadKey();
        }
        private static void obj1Info()
        {
            Singleton obj1 = Singleton.Instance;
            obj1.printInfo();
            Console.WriteLine(obj1.GetHashCode());
        }
        private static void obj2Info()
        {
            Singleton obj2 = Singleton.Instance;
            obj2.printInfo();
            Console.WriteLine(obj2.GetHashCode());
        }
        public static void LogInformation()
        {
            string fileName = String.Format("{0}-{1}","Exception",DateTime.UtcNow.ToShortDateString()+".txt");
            string filePath = String.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            string message = "This is my first I/O Exception!";
            StringBuilder sb= new StringBuilder();
            sb.Append("---- Start Writing to file ----");
            sb.Append(message);
            sb.Append("---- End Writing ----!");
            using (StreamWriter writer = new StreamWriter(filePath,true))
            {
                writer.WriteLine(sb.ToString());
                writer.Flush();
            }
        }
    }
}
