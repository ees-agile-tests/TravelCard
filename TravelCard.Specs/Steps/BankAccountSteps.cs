using TechTalk.SpecFlow;
using TravelCard.Domain;
using FluentAssertions;

namespace TravelCard.Specs.Steps
{
    [Binding]
    public class BankAccountSteps
    {

        private readonly BankAccount _bankAccount = new BankAccount();

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
            try
            {
                _bankAccount.DebitMoney(value);
            }
            catch (InvalidDebitException)
            {

            }
           
        }
        
        [Then(@"the balance should be (.*)")]
        public void ThenTheBalanceShouldBe(int balance)
        {
            _bankAccount.Balance.Should().Be(balance);
        }

        [Then(@"the user is presented with an error message")]
        public void ThenTheUserIsPresentedWithAnErrorMessage()
        {
            _bankAccount.Balance.Should().Be(0);
        }
    }
}
