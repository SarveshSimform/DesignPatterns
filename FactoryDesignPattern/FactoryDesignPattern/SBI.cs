using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class SBI : ICreditCard
    {
        public CreditCardModel PrintDetails(CreditCardModel creditCardModel)
        {
            creditCardModel.CardId = (int)EnumCreditCard.SBI;
            creditCardModel.CardName = Enum.GetName(typeof(EnumCreditCard), (int)EnumCreditCard.SBI);
            creditCardModel.CardExpiryDate = DateTime.Now.ToShortDateString();
            return creditCardModel;
        }
        public decimal ChargesOnCard()
        {
            return 2000;
        }
    }
}
