using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    public class ConcreteUser : User
    {
        public ConcreteUser(Mediator mediator, string name) : base(mediator, name)
        {
        }

        public override void ReceiveMessage(string msg)
        {
            Console.WriteLine(this.name + ": Received Message:" + msg);
        }

        public override void SendMessage(string msg)
        {
            Console.WriteLine(this.name + ": Sending Message=" + msg + "\n");
            mediator.SendMessage(msg,this);
        }
    }
}
