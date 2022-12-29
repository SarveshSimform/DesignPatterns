using FactoryDesignPattern.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FactoryDesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Please Enter Credit Card Id that you wants to display information");
            //int creditCardId = Convert.ToInt32(Console.ReadLine());
            //ICreditCard creditCard = new CreditCardFactory().GetCreditCard(creditCardId);
            //if (creditCard != null)
            //    creditCard.PrintDetails();
            //else
            //    Console.WriteLine("Invalid Input !!!");
            Console.WriteLine("Please Enter Credit Card Id that you wants to display information");
            int creditCardId = Convert.ToInt32(Console.ReadLine());
            BaseCreditCardFactory baseCreditCard = new CardManagerFactory().GetCreditCardFactory(creditCardId);
            if (baseCreditCard != null)
            {
                var creditCard = baseCreditCard.CreateCreditCard();
                var result = baseCreditCard.GetInfo(creditCard);
                var ans = JsonConvert.SerializeObject(result);
                Console.WriteLine(ans);
            }
            else
                Console.WriteLine("Invalid Input !!!");
            Console.ReadKey();

        }
    }
}
