using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TravelCard.Domain.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void VerifyDebitMoneyTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());

            var bankAccount = bankAccountMock.Object;
            var today = new DateTime(2021, 04, 25);
            var tomorrow = today.AddDays(1);
            var card = new Card(bankAccount, today);
            card.AuthorizeDebit(Fare.ZoneA_Daily, tomorrow);

            bankAccountMock.Verify(x => x.DebitMoney(It.IsAny<decimal>()));
        }

         [TestMethod]
        public void VerifyNoDebitMoneyTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());

            var bankAccount = bankAccountMock.Object;
            var today = new DateTime(2021, 04, 25);
            var card = new Card(bankAccount, today);
            card.AuthorizeDebit(Fare.ZoneA_Daily, today);

            bankAccountMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void AssertChangeExpirationDateTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());

            var bankAccount = bankAccountMock.Object;
            var today = new DateTime(2021, 04, 25);
            var tomorrow = today.AddDays(1);
            var card = new Card(bankAccount, today);
            card.AuthorizeDebit(Fare.ZoneA_Daily, tomorrow);

            Assert.AreEqual(tomorrow, card.ExpirationDate);
        }

        [TestMethod]
        public void AssertNoChangeExpirationDateTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());

            var bankAccount = bankAccountMock.Object;
            var today = new DateTime(2021, 04, 25);
            var card = new Card(bankAccount, today);
            card.AuthorizeDebit(Fare.ZoneA_Daily, today);

            Assert.AreEqual(today, card.ExpirationDate);
        }
    }
}
