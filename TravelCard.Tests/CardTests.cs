using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TravelCard.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void DebitAccountTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());
            bankAccountMock.Setup(x => x.DebitMoney(It.IsAny<decimal>()));

            var bankAccount = bankAccountMock.Object;
            var card = new Card(bankAccount);
            card.DebitAccount(It.IsAny<decimal>());

            bankAccountMock.Verify(x => x.DebitMoney(It.IsAny<decimal>()));
        }
    }
}
