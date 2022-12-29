using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class HDFC : ICreditCard
    {
        public CreditCardModel PrintDetails(CreditCardModel creditCardModel)
        {
            creditCardModel.CardId = (int)EnumCreditCard.HDFC;
            creditCardModel.CardName = Enum.GetName(typeof(EnumCreditCard), (int)EnumCreditCard.HDFC);
            creditCardModel.CardExpiryDate = DateTime.Now.ToShortDateString();
            return creditCardModel;
        }
        public decimal DiscountOnCard()
        {
            return 5000;
        }
    }
}
