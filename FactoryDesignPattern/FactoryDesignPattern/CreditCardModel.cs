using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class CreditCardModel
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public decimal CardCharges { get; set; }
        public decimal DiscountOnCard { get; set; }
        public string CardExpiryDate {get; set; }

    }
}
