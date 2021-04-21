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
            card.Charge(It.IsAny<Fare>());

            bankAccountMock.Verify(x => x.DebitMoney(It.IsAny<decimal>()));
        }
    
        [TestMethod]
        public void ChargeFareTestSuccess()
        {
            var bankAccount = new BankAccount(123, 100);
            var card = new Card(bankAccount);

            card.Charge(Fare.ZonaA_Daily);
            Assert.AreEqual(90, card.BankAccount.Balance);
        }

        [TestMethod]
        public void ChargeFareTestFail()
        {
            var bankAccount = new BankAccount(123, 0);
            var card = new Card(bankAccount);

            Assert.ThrowsException<InvalidChargeException>(() => card.Charge(Fare.ZonaA_Daily));
        }
    }
}
