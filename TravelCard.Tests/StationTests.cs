using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TravelCard.Tests
{
    [TestClass]
    public class StationTests
    {
        [TestMethod]
        public void CheckInTest()
        {
            var bankAccountMock = new Mock<BankAccount>(It.IsAny<long>(), It.IsAny<decimal>());
            var card = new Card(bankAccountMock.Object);
            var station = new Station(Zone.A);

            var requestDate = new DateTime(2020, 04, 25);

            card.Zone = Zone.A;
            station.CheckIn(card, Fare.ZoneA_Daily, requestDate);
        }
    }
}
