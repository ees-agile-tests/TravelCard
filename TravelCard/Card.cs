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

        public void DebitAccount(decimal debit)
        {
            BankAccount.DebitMoney(debit);
        }
    }
}
