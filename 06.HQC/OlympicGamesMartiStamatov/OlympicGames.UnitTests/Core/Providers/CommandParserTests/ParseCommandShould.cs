using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;
using OlympicGames.UnitTests.Core.Providers.CommandParserTests.Mocks;

namespace OlympicGames.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommandShould
    {
        [TestMethod]
        public void InvokeCreateOnCommandFactory()
        {
            //Arrange
            var mockFactory = new Mock<ICommandFactory>();
            var parser = new CommandParser(mockFactory.Object);

            // !!! mockFactory.Setup(x => x.Create(It.IsAny<string>())).Returns(ICommand listolympians);
            //   mockFactory.SetupSequence(x => x.Create(It.IsAny<string>())).Returns().Returns()
            //Act
            parser.ParseCommand("test");
            //Assert
            mockFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Once);


        }
    }
}
