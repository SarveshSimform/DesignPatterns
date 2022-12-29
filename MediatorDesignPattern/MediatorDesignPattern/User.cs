using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    public abstract class User
    {
        protected Mediator mediator;
        protected string name;
        public User(Mediator mediator,string name)
        {
            this.mediator = mediator;
            this.name = name;
        }
        public abstract void SendMessage(string msg);
        public abstract void ReceiveMessage(string msg);
    }
}
