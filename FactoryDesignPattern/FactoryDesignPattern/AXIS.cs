using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class AXIS : ICreditCard
    {
        public CreditCardModel PrintDetails(CreditCardModel creditCardModel)
        {
            creditCardModel.CardId = (int)EnumCreditCard.AXIS;
            creditCardModel.CardName = Enum.GetName(typeof(EnumCreditCard), (int)EnumCreditCard.AXIS);
            creditCardModel.CardExpiryDate = DateTime.Now.ToShortDateString();
            return creditCardModel;
        }
    }
}
