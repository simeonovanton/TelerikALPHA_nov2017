﻿namespace JustBelot.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class Contract_RoundPoints
    {
        [TestMethod]
        public void AllTrump0()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(0, false);
            Assert.AreEqual(0, roundedPoints);
        }

        [TestMethod]
        public void AllTrump258()
        {
            var contract = new Contract(PlayerPosition.West, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(258, false);

            Assert.AreEqual(25, roundedPoints);
        }

        [TestMethod]
        public void AllTrump155()
        {
            var contract = new Contract(PlayerPosition.North, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(155, true);
            Assert.AreEqual(15, roundedPoints);
        }

        [TestMethod]
        public void AllTrump153()
        {
            var contract = new Contract(PlayerPosition.South, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(153, false);
            Assert.AreEqual(15, roundedPoints);
        }

        [TestMethod]
        public void AllTrump154Winner()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(154, true);
            Assert.AreEqual(17, roundedPoints);
        }

        [TestMethod]
        public void AllTrump154Loser()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(154, false);
            Assert.AreEqual(15, roundedPoints);
        }

        [TestMethod]
        public void AllTrump3()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.AllTrumps);
            var roundedPoints = contract.RoundPoints(3, false);
            Assert.AreEqual(0, roundedPoints);
        }

        [TestMethod]
        public void NoTrump130()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.Clubs);
            var roundedPoints = contract.RoundPoints(130, false);
            Assert.AreEqual(17, roundedPoints);
        }

        [TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        public void NoTrump134()
        {
            var contract = new Contract(PlayerPosition.West, ContractType.NoTrumps);
            var roundedPoints = contract.RoundPoints(134, false);
            Assert.AreEqual(13, roundedPoints);
        }

        [TestMethod]
        public void NoTrump136()
        {
            var contract = new Contract(PlayerPosition.North, ContractType.Diamonds);
            var roundedPoints = contract.RoundPoints(136, false);
            Assert.AreEqual(13, roundedPoints);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoTrump260()
        {
            var contract = new Contract(PlayerPosition.South, ContractType.NoTrumps);
            var roundedPoints = contract.RoundPoints(260, true);
            Assert.AreEqual(26, roundedPoints);
        }

        [TestMethod]
        public void NoTrump0()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.NoTrumps);
            var roundedPoints = contract.RoundPoints(10, true);
            Assert.AreEqual(0, roundedPoints);
        }

        [TestMethod]
        public void Trump0()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.Spades);
            var roundedPoints = contract.RoundPoints(0, false);
            Assert.AreEqual(0, roundedPoints);
        }

        [TestMethod]
        public void Trump162()
        {
            var contract = new Contract(PlayerPosition.West, ContractType.Diamonds);
            var roundedPoints = contract.RoundPoints(162, false);
            Assert.AreEqual(15, roundedPoints);
        }

        [TestMethod]
        public void Trump87()
        {
            var contract = new Contract(PlayerPosition.North, ContractType.Hearts);
            var roundedPoints = contract.RoundPoints(87, true);
            Assert.AreEqual(9, roundedPoints);
        }

        [TestMethod]
        public void Trump85()
        {
            var contract = new Contract(PlayerPosition.South, ContractType.Clubs);
            var roundedPoints = contract.RoundPoints(85, false);
            Assert.AreEqual(8, roundedPoints);
        }

        [TestMethod]
        public void Trump86Loser()
        {
            var contract = new Contract(PlayerPosition.East, ContractType.Clubs);
            var roundedPoints = contract.RoundPoints(86, true);
            Assert.AreEqual(9, roundedPoints);
        }

        [TestMethod]
        public void Trump86Winner()
        {
            var contract = new Contract(PlayerPosition.West, ContractType.Hearts);
            var roundedPoints = contract.RoundPoints(86, true);
            Assert.AreEqual(10, roundedPoints);
        }

        [TestMethod]
        public void Trump76Loser()
        {
            var contract = new Contract(PlayerPosition.North, ContractType.Spades);
            var roundedPoints = contract.RoundPoints(6, false);
            Assert.AreEqual(8, roundedPoints);
        }

        [TestMethod]
        public void Trump76Winner()
        {
            var contract = new Contract(PlayerPosition.South, ContractType.Diamonds);
            var roundedPoints = contract.RoundPoints(76, true);
            Assert.AreEqual(76, roundedPoints);
        }
    }
}
