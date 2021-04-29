using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TravelCard.Tests
{
    [TestClass]
    public class StationTests
    {
        [TestMethod]
        public void CheckInSuccessTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());
            var card = new Card(bankAccountMock.Object);
            var station = new Station(Zone.A);

            var requestDate = new DateTime(2020, 04, 25);

            card.Zone = Zone.A;
            station.CheckIn(card, Fare.ZoneA_Daily, requestDate);
        }

        [TestMethod]
        public void CheckInFailTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());
            var card = new Card(bankAccountMock.Object);
            var station = new Station(Zone.B);

            var requestDate = new DateTime(2020, 04, 25);
            card.Zone = Zone.A;
            
            Assert.ThrowsException<InvalidZoneException>(() => station.CheckIn(card, Fare.ZoneA_Daily, requestDate));
        }

        [TestMethod]
        public void CheckInRequestDateExpired()
        {
            var bankAccount = new BankAccount(123, 100);
            var cardMock = new Mock<Card>(bankAccount);
            var station = new Station(Zone.B);

            var card = cardMock.Object;

            var requestDate = DateTime.Now.AddDays(1);
            card.ExpirationDate = DateTime.Now;
            card.Zone = Zone.A;

            station.CheckIn(card, Fare.ZoneA_Daily, requestDate);

            cardMock.Verify(x => x.AuthorizeDebit(It.IsAny<Fare>()));
        }
    }
}
