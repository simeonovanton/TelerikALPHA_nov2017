using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.CreateTicketCommandTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void SetCorrectDataField()
        {
            //Arrange
            var mockData = new Mock<IDataBase>();
            var mockFactory = new Mock<ITravellerFactory>();
            var mockConstant = new Constants();
            var ticket = new MockedCreateTicketCommand(mockData.Object, mockFactory.Object, mockConstant);
            // use direct instance of <Constants> cless, because there
            // it's just for container usage, no dependencies, no interface.

            //Act & Assert
            Assert.AreSame(ticket.exposedData, mockData.Object);
        }

        [TestMethod]
        public void SetCorrectFactoryField()
        {
            //Arrange
            var mockData = new Mock<IDataBase>();
            var mockFactory = new Mock<ITravellerFactory>();
            var mockConstant = new Constants();
            var ticket = new MockedCreateTicketCommand(mockData.Object, mockFactory.Object, mockConstant);
            // use direct instance of <Constants> cless, because there
            // it's just for container usage, no dependencies, no interface.

            //Act & Assert
            Assert.AreSame(ticket.exposedFactory, mockFactory.Object);
        }

        [TestMethod]
        public void SetCorrectConstantsField()
        {
            //Arrange
            var mockData = new Mock<IDataBase>();
            var mockFactory = new Mock<ITravellerFactory>();
            var mockConstant = new Constants();
            var ticket = new MockedCreateTicketCommand(mockData.Object, mockFactory.Object, mockConstant);
            // use direct instance of <Constants> cless, because there
            // it's just for container usage, no dependencies, no interface.

            //Act & Assert
            Assert.AreSame(ticket.exposedConstants, mockConstant);
        }


        [TestMethod]
        public void InvokeExecuteMethodAndThrowsArgumentException()
        {
            //Arrange
            var mockData = new Mock<IDataBase>();
            var mockFactory = new Mock<ITravellerFactory>();
            var mockConstant = new Constants();
            var command = new Mock<ICommand>();
            // use direct instance of <Constants> cless, because there
            // it's just for container usage, no dependencies, no interface.
            var parameters = new List<string> { "10", "20" };
            var ticket = new MockedCreateTicketCommand(mockData.Object, mockFactory.Object, mockConstant);

            //Act & Assert
            Assert.ThrowsException<System.ArgumentException>(() => ticket.Execute(parameters));
        }
    }
}
