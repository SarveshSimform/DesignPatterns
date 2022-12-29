using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    public class ConcreterMediator : Mediator
    {
        private List<User> users = new List<User>();
        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        public void SendMessage(string msg, User user)
        {
            if(users?.Count > 0)
            {
                foreach (var u in users)
                {
                    if(u != user)
                    {
                        u.ReceiveMessage(msg);
                    }
                }
            }
        }
    }
}
