using Agency.Models.Contracts;
using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Agency.Tests.Models.JourneyTests
{
    [TestClass]
   public  class JourneyConstructor_Should
    {
        [TestMethod]
        public void Assign_Correct_Values()
        {
            //arrange
            string startLocation = "ishjkkks";
            string destination = "ddddiid";
            int distance = 2200;
            Mock<IVehicle> vehicle = new Mock<IVehicle>();

            //act
            Journey journey = new Journey(startLocation, destination, distance, vehicle.Object);

            //assert
            Assert.AreEqual(startLocation, journey.StartLocation);
            Assert.AreEqual(destination, journey.Destination);
            Assert.AreEqual(distance, journey.Distance);
            Assert.AreSame(vehicle.Object, journey.Vehicle);
        }
        

        //[TestMethod]
        //public void Assign_Correct_Location()
        //{
        //    //arrange
        //    string startLocation = "ssiiiiss";
        //    string destination = "dddiidd";
        //    int distance = 2200;
        //    Mock<IVehicle> vehicle = new Mock<IVehicle>();

        //    //act
        //    Journey journey = new Journey(startLocation, destination, distance, vehicle.Object);

        //    //assert
        //    Assert.AreEqual(startLocation, journey.StartLocation, "Start Location Failed");

        //}
        //[TestMethod]
        //public void Assign_Correct_Destination()
        //{
        //    //arrange
        //    string startLocation = "ssiiss";
        //    string destination = "ddddiid";
        //    int distance = 2200;
        //    Mock<IVehicle> vehicle = new Mock<IVehicle>();

        //    //act
        //    Journey journey = new Journey(startLocation, destination, distance, vehicle.Object);

        //    //assert
        //    Assert.AreEqual(destination, journey.Destination,"Incorrect destination");

        //}
        //[TestMethod]
        //public void Assign_Correct_Distance()
        //{
        //    //arrange
        //    string startLocation = "ssiiiiss";
        //    string destination = "iiiiiii";
        //    int distance = 2200;
        //    Mock<IVehicle> vehicle = new Mock<IVehicle>();

        //    //act
        //    Journey journey = new Journey(startLocation, destination, distance, vehicle.Object);

        //    //assert

        //    Assert.AreEqual(distance, journey.Distance, "Distance failed");
        //}
        //[TestMethod]
        //public void Assign_Correct_Vehicle()
        //{
        //    //arrange
        //    string startLocation = "ssiiiiss";
        //    string destination = "ddiiiiddd";
        //    int distance = 2200;
        //    Mock<IVehicle> vehicle = new Mock<IVehicle>();

        //    //act
        //    Journey journey = new Journey(startLocation, destination, distance, vehicle.Object);

        //    //assert

        //    Assert.AreSame(vehicle.Object, journey.Vehicle, "Vehicle Failed");
        //}


    }
}
