using Academy.Commands.Creating;
using Academy.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Creating
{
    [TestClass]
    public class Execute_Shuld
    {
        [TestMethod]
        public void ThrowArgumentNullException()
        {
            //Arrange
            var fakeEngine = new Mock<IEngine>();
            var fakeFactory = new Mock<IAcademyFactory>();
            var createTrainerCommand = new CreateTrainerCommand(fakeFactory.Object, fakeEngine.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(()=>createTrainerCommand.Execute(null));
        }
    }
}
