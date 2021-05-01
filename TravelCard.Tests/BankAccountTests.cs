using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelCard.Domain;

namespace TravelCard.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void DepositMoneyTest()
        {
            var bankAccount = new BankAccount(123, 0);
            bankAccount.DepositMoney(100);

            Assert.AreEqual(100, bankAccount.Balance);
        }

        [TestMethod]
        public void DebitMoneySuccessTest()
        {
            var bankAccount = new BankAccount(123, 100);

            bankAccount.DebitMoney(100);
            Assert.AreEqual(0, bankAccount.Balance);
        }

        [TestMethod]
        public void DebitMoneyFailTest()
        {
            var bankAccount = new BankAccount(123, 0);

            Assert.ThrowsException<InvalidDebitException>(() => bankAccount.DebitMoney(100));
        }

    }
}
