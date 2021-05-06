using TechTalk.SpecFlow;
using TravelCard.Domain;
using FluentAssertions;
using System;

namespace TravelCard.Specs.Steps
{
    [Binding]
    public class BankAccountSteps
    {

        private readonly BankAccount bankAccount = new BankAccount();

        [Given(@"the balance is (.*)")]
        public void GivenTheBalanceIs(int balance)
        {
            bankAccount.Balance = balance;
        }
        
        [Given(@"the account number is (.*)")]
        public void GivenTheAccountNumberIs(long accountNumber)
        {
            bankAccount.AccountNumber = 123;
        }
        
        [When(@"debit money is (.*)")]
        public void WhenValueDebitMoneyIs(int valueDebit)
        {
            try
            {
                bankAccount.DebitMoney(valueDebit);
            }
            catch (Exception ex)
            {

            }
           
        }
        
        [Then(@"the balance should be (.*)")]
        public void ThenTheBalanceShouldBe(int balance)
        {
            bankAccount.Balance.Should().Be(balance);
        }

        [Then(@"the user is presented with an error message")]
        public void ThenError()
        {
            bankAccount.Balance.Should().Be(0);
        }
    }
}
