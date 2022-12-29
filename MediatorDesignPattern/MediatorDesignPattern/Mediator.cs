using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    public interface Mediator
    {
        void RegisterUser(User user);
        void SendMessage(string msg, User user);
    }
}
