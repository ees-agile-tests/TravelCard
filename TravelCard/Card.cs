using System;

namespace TravelCard.Domain
{
    public class Card
    {
        public DateTime ExpirationDate { get; set; }
        public BankAccount BankAccount { get; set; }
        public Zone Zone { get; set; }

        public Card(BankAccount bankAccount)
        {
            BankAccount = bankAccount;
            ExpirationDate = DateTime.Now;
        }

        public Card(BankAccount bankAccount, DateTime expirationDate)
        {
            BankAccount = bankAccount;
            ExpirationDate = expirationDate;
        }

        public virtual void AuthorizeDebit(Fare fare)
        {
            var requestDate = DateTime.Now;

            AuthorizeDebit(fare, requestDate);
        }

        public void AuthorizeDebit(Fare fare, DateTime requestDate)
        {
            if (requestDate > ExpirationDate)
            {
                BankAccount.DebitMoney(Convert.ToDecimal(fare));
                UpdateExpirationDate(fare);
            }
        }

        private void UpdateExpirationDate(Fare fare)
        {
            switch (fare)
            {
                case Fare.ZoneA_Daily:
                case Fare.ZoneB_Daily:
                    ExpirationDate = ExpirationDate.AddDays(1);
                    break;
                case Fare.ZoneA_Weekly:
                case Fare.ZoneB_Weekly:
                    ExpirationDate = ExpirationDate.AddDays(7);
                    break;
                case Fare.ZoneA_Monthly:
                case Fare.ZoneB_Monthly:
                    ExpirationDate = ExpirationDate.AddMonths(1);
                    break;
                default:
                    return;
            }
        }
    }
}
