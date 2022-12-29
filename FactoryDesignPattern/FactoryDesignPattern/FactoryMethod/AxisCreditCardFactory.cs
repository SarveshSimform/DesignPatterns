using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.FactoryMethod
{
    public class AxisCreditCardFactory : BaseCreditCardFactory
    {
        public AxisCreditCardFactory(CreditCardModel creditCardModel) : base(creditCardModel)
        {
        }

        public override ICreditCard CreateCreditCard()
        {
           AXIS obj = new AXIS();
            return obj;
        }
    }
}
