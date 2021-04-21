﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            Assert.AreEqual(100, bankAccount.Balance);
        }

        [TestMethod]
        public void DebitMoneySuccessTest()
        {
            BankAccount bankAccount = new BankAccount(123, 100);

            bankAccount.DebitMoney(100);
            Assert.AreEqual(0, bankAccount.Balance);
        }

        [TestMethod]
        public void DebitMoneyFailTest()
        {
            BankAccount bankAccount = new BankAccount(123, 0);

            Assert.ThrowsException<InvalidChargeException>(() => bankAccount.DebitMoney(100));
        }

    }
}
