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
            var bankAccountMock = new Mock<BankAccount>();
            bankAccountMock.Setup(mock => mock.DebitMoney(100));

            var card = new Card(bankAccountMock.Object);
            card.DebitAccount(100);

            bankAccountMock.Verify(mock => mock.DebitMoney(100));
        }
    }
}
