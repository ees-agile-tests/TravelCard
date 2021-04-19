using System;

namespace TravelCard.Tests
{
    public class BankAccount
    {
        public long AccountNumber { get; set; }
 
        public decimal Balance { get; set; }

        public BankAccount(long accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        public void DebitMoney(decimal debit)
        {
            if (ValidateDebit(debit))
                this.Balance -= debit;
        }

        public void DepositMoney(decimal desposit)
        {
            if (ValidateDeposit(desposit))
                this.Balance += desposit;
        }

        private bool ValidateDeposit(decimal deposit)
        {
            if (deposit < 0)
                return false;

            return true;
        }

        private bool ValidateDebit(decimal debit)
        {
            if ((this.Balance - debit) < 0)
                return false;

            if (debit < 0)
                return false;

            return true;
        }
    }
}