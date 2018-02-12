using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Traveller.UnitTests.CommandParserTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void SetProperlyTheFieldContainer()
        {
            //Arrange
            var container = new Mock<IComponentContext>();
            var comParser = new MockedCommandParser(container.Object);
            //Act & Assert
            Assert.AreSame(comParser.Container, container.Object);
        }
    }
}
