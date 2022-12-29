using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern.FactoryMethod
{
    public abstract class BaseCreditCardFactory
    {
        protected CreditCardModel _CreditCardModel;
        public BaseCreditCardFactory(CreditCardModel creditCardModel)
        {
            this._CreditCardModel = creditCardModel;
        }
        public CreditCardModel GetInfo(ICreditCard creditCard)
        {
            //ICreditCard creditCard = this.CreateCreditCard();
            var result = creditCard.PrintDetails(_CreditCardModel);
            return result;
        }
        public abstract ICreditCard CreateCreditCard();
    }
}
