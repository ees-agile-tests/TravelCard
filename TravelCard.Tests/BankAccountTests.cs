using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelCard.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void DepositMoneyTest()
        {
            BankAccount bankAccount = new BankAccount(123, 0);
            bankAccount.DepositMoney(100);

            Assert.AreEqual(bankAccount.Balance, 100);
        }

        [TestMethod]
        public void DebitMoneySuccessTest()
        {
            BankAccount bankAccount = new BankAccount(123, 100);

            bankAccount.DebitMoney(100);
            Assert.AreEqual(bankAccount.Balance, 0);
        }

        [TestMethod]
        public void DebitMoneyFailTest()
        {
            BankAccount bankAccount = new BankAccount(123, 0);

            Assert.ThrowsException<InvalidChargeException>(() => bankAccount.DebitMoney(100));
        }
    }
}
