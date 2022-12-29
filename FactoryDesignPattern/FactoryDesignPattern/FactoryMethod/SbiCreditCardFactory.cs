using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.FactoryMethod
{
    public class SbiCreditCardFactory : BaseCreditCardFactory
    {
        public SbiCreditCardFactory(CreditCardModel creditCardModel) : base(creditCardModel)
        {
        }

        public override ICreditCard CreateCreditCard()
        {
            SBI obj = new SBI();
            _CreditCardModel.CardCharges = obj.ChargesOnCard();
            return obj;
        }
    }
}
