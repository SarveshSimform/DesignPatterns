using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.FactoryMethod
{
    public class CardManagerFactory
    {
        public BaseCreditCardFactory GetCreditCardFactory(int creditCardId)
        {
            CreditCardModel creditCardModel = new CreditCardModel();
            EnumCreditCard creditCard = (EnumCreditCard)creditCardId;
            BaseCreditCardFactory obj = null;
            if (creditCard == EnumCreditCard.HDFC)
            {
                obj = new HdfcCreditCardFactory(creditCardModel);
            }
            else if (creditCard == EnumCreditCard.SBI)
            {
                obj = new SbiCreditCardFactory(creditCardModel);
            }
            else if (creditCard == EnumCreditCard.AXIS)
            {
                obj = new AxisCreditCardFactory(creditCardModel);
            }
            return obj;
        }
    }
}
