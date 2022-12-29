using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class CreditCardFactory
    {
        public ICreditCard GetCreditCard(int creditCardId)
        {
            EnumCreditCard creditCard = (EnumCreditCard)creditCardId;
            ICreditCard obj = null;
            if (creditCard == EnumCreditCard.HDFC)
            {
                obj = new HDFC();
            }
            else if (creditCard == EnumCreditCard.SBI)
            {
                obj = new SBI();
            }
            else if (creditCard == EnumCreditCard.AXIS)
            {
                obj = new AXIS();
            }
            return obj;
        }
    }
}
