using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.FactoryMethod
{
    public class HdfcCreditCardFactory : BaseCreditCardFactory
    {
        public HdfcCreditCardFactory(CreditCardModel creditCardModel) : base(creditCardModel)
        {
        }

        public override ICreditCard CreateCreditCard()
        {
            HDFC obj = new HDFC();
            _CreditCardModel.DiscountOnCard = obj.DiscountOnCard();
            return obj;
        }
    }
}
