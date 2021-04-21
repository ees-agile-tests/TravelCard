using System;

namespace TravelCard
{
    public class Card
    {
        public BankAccount BankAccount { get; set; }

        public Card(BankAccount bankAccount)
        {
            BankAccount = bankAccount;
        }

        public void Charge(Fare fare) 
        {
            BankAccount.DebitMoney(Convert.ToDecimal(fare));
        }
    }
}
