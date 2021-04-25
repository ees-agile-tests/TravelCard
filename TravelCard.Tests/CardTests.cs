using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TravelCard.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void VerifyDebitMoneyTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());

            var bankAccount = bankAccountMock.Object;
            var card = new Card(bankAccount);
            card.Authorize(It.IsAny<Fare>());

            bankAccountMock.Verify(x => x.DebitMoney(It.IsAny<decimal>()));
        }

        [TestMethod]
        public void AuthorizeSuccessTest()
        {
            var bankAccount = new BankAccount(123, 100);
            var card = new Card(bankAccount);

            card.Authorize(Fare.ZoneA_Daily);
            Assert.AreEqual(90, card.BankAccount.Balance);
        }

        [TestMethod]
        public void AuthorizeFailTest()
        {
            var bankAccount = new BankAccount(123, 0);
            var card = new Card(bankAccount);

            Assert.ThrowsException<InvalidChargeException>(() => card.Authorize(Fare.ZoneA_Daily));
        }

        [TestMethod]
        public void ExpirationDateTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());

            var bankAccount = bankAccountMock.Object;
            var initialExpirationDate = Convert.ToDateTime("2021-04-25");
            var card = new Card(bankAccount, initialExpirationDate);
            card.Authorize(Fare.ZoneA_Daily);

            Assert.AreEqual(initialExpirationDate.AddDays(1), card.ExpirationDate);
        }
    }
}
