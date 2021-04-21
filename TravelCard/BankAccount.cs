using System;

namespace TravelCard
{
    public class BankAccount
    {
        public long AccountNumber { get; set; }
 
        public decimal Balance { get; set; }

        public BankAccount()
        {
        }

        public BankAccount(long accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        public virtual void DebitMoney(decimal debit)
        {
            if (!ValidateDebit(debit))
                throw new InvalidChargeException("Balance is not enougth");
            this.Balance -= debit;
        }

        public void DepositMoney(decimal desposit)
        {
            if (!ValidateDeposit(desposit))
                throw new InvalidChargeException("Value must be positive");
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