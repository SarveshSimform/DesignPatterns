using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mediator mediator = new ConcreterMediator();
            User sarvesh = new ConcreteUser(mediator,"sarvesh");
            User rikesh = new ConcreteUser(mediator,"rikesh");
            User divya = new ConcreteUser(mediator,"divya");
            mediator.RegisterUser(sarvesh);
            mediator.RegisterUser(rikesh);
            mediator.RegisterUser(divya);
            sarvesh.SendMessage("Hi all of you, how are you guys!!!");
            Console.WriteLine();
            rikesh.SendMessage("Hi Sarvesh, I am fine bro!!!");
           // Rajesh.SendMessage("What is Design Patterns? Please explain ");
            Console.Read();
            //Real life example of mediator is ms team channel for announcement
            //second one is Air traffic controller for give information to pilot
        }
    }
}
