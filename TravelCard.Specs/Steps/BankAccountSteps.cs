using TechTalk.SpecFlow;
using TravelCard.Domain;
using FluentAssertions;

namespace TravelCard.Specs.Steps
{
    [Binding]
    public class BankAccountSteps
    {
        private readonly BankAccount _bankAccount = new();

        [Given(@"the balance is (.*)")]
        public void GivenTheBalanceIs(int balance)
        {
            _bankAccount.Balance = balance;
        }
        
        [Given(@"the account number is (.*)")]
        public void GivenTheAccountNumberIs(int accountNumber)
        {
            _bankAccount.AccountNumber = 123;
        }
        
        [When(@"debit money (.*)")]
        public void WhenDebitMoney(int value)
        {
            _bankAccount.DebitMoney(value);
        }
        
        [When(@"deposit money (.*)")]
        public void WhenDepositMoney(int value)
        {
            _bankAccount.DepositMoney(value);
        }
        
        [Then(@"the balance should be (.*)")]
        public void ThenTheBalanceShouldBe(int balance)
        {
            _bankAccount.Balance.Should().Be(balance);
        }
        
    }
}
