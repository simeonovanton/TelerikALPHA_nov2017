using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Agency.Tests.Models.JourneyTests
{
    [TestClass]
    public class Journey_StartLocation_Should
    {
        [TestMethod]
        public void Throw_ArgumentException_When_Value_IsBelow_5()
        {
            //Arrange
            string startLocation = "33dss3";
            string destination = "asdasd";
            int distance = 100;
            Mock<IVehicle> vehicle = new Mock<IVehicle>();
            Mock<IVehicle> vehicle2 = new Mock<IVehicle>();
            Mock<IVehicle> vehicle3 = new Mock<IVehicle>();
            Mock<IVehicle> vehicle4 = new Mock<IVehicle>();

            //vehicle.Setup(x => x.GetHashCode());



            vehicle3.Verify(x => x.GetHashCode(), );

            //Act
            //Journey journey = new Journey()

        //Assert

        }
    }
}
