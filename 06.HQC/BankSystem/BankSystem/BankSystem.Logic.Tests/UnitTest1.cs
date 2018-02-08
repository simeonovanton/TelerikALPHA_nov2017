using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankSystem.Logic.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void ConstructorShouldSetMoneyToZero()
        {
            //Arrange && Act
            var loggerMock = new Mock<ILogger>();
            var bankAccount = new BankAccount(loggerMock.Object);
            //Assert
            Assert.AreEqual(0, bankAccount.Money);
        }

        [TestMethod]
        public void DepositShouldAddToAccountMoney()
        {
            var loggerMock = new Mock<ILogger>();
            var bankAccount = new BankAccount(loggerMock.Object);
            //Act
            bankAccount.Deposit(1457);
            //Assert
            Assert.AreEqual(1457, bankAccount.Money);
        }

        [TestMethod]
        public void DepositAndWithdrawShouldLeaveMoneyToZero()
        {
            //Arrange
            var loggerMock = new Mock<ILogger>();
            var bankAccount = new BankAccount(loggerMock.Object);
            //Act
            bankAccount.Deposit(1457);
            bankAccount.Withdraw(1457);
            //Assert
            Assert.AreEqual(0, bankAccount.Money);
        }

        [TestMethod]
        public void DepositShouldLogTransaction()
        {
            var mockedLogger = new Mock<ILogger>();
            var bankAccount = new BankAccount(mockedLogger.Object);
            bankAccount.Deposit(1000);
            //Assert.IsTrue(mockedLogger.LogIsCalled);
            //mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(1));
            mockedLogger.Verify(x => x.Log(It.Is<string>(y => y.Contains("deposit"))), Times.Exactly(1));
        }

    }

    /*public class IsLogMethodCalledLogger : ILogger
    {
        public bool LogIsCalled { get; private set; }
        public void Log(string message)
        {
            this.LogIsCalled = true;
        }
    }*/
}
