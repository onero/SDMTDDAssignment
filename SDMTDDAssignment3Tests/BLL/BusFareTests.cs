using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDMTDDAssignment3.BLL;

namespace SDMTDDAssignment3Tests.BLL
{
    [TestClass()]
    public class BusFareTests
    {
        private const double InitialFee = 130.0;
        private const double Below100Fee = 3.20;
        private const double Above100Below500LessThan12PassengersFee = 2.75;
        private const double Above100Below500_12OrMorePassengersFee = 3.00;
        private const double Above500Fee = 2.25;

        private const int HundredDistance = 99;
        private const int FiveHundredDistance = 499;

        private IBusFare _bus;

        [TestInitialize]
        public void Initialize()
        {
            _bus = new BusFare();
        }

        //Initial fee is 130,-
        [TestMethod()]
        public void TotalCostTest_NoDistanceTraveled_InitialFee()
        {
            var noOfPassengers = 13;
            var distance = 0;

            var expectedResult = InitialFee;
            var result = _bus.TotalCost(noOfPassengers, distance);

            Assert.AreEqual(expectedResult, result);
        }


        //Anything below 100 km, 3.20,- pr km regardsless of passengers.
        [TestMethod()]
        public void TotalCost_Below100Travelled_DistanceTimeBelow100Fee()
        {
            var noOfPassengers = 13;
            var distance = 50;

            var expectedResult = distance * Below100Fee + InitialFee;
            var result = _bus.TotalCost(noOfPassengers, distance);

            Assert.AreEqual(expectedResult, result);
        }

        //Above 100 but below 500 km, 2.75,- with less than twelve passengers.
        [TestMethod]
        public void TotalCost_Above100Below500Travelled_LessThan12Passengers()
        {
            var noOfPassengers = 10;
            var distance = 250;

            var above100Distance = distance - HundredDistance;
            var belowHundredCost = (HundredDistance * Below100Fee);
            var above100Below500Less12PassengersCost = (above100Distance * Above100Below500LessThan12PassengersFee);

            var expectedResult = belowHundredCost + above100Below500Less12PassengersCost + InitialFee;
            var result = _bus.TotalCost(noOfPassengers, distance);

            Assert.AreEqual(expectedResult, result);
        }

        //Above 100 but below 500 km 3.00 ,- with more than twelve passengers.
        [TestMethod]
        public void TotalCost_Above100Below500Travelled_12OrMorePassengers() {
            var noOfPassengers = 15;
            var distance = 250;

            var above100Distance = distance - HundredDistance;
            var belowHundredCost = (HundredDistance * Below100Fee);
            var above100Below500_12OrMorePassengersCost = (above100Distance * Above100Below500_12OrMorePassengersFee);

            var expectedResult = belowHundredCost + above100Below500_12OrMorePassengersCost + InitialFee;
            var result = _bus.TotalCost(noOfPassengers, distance);

            Assert.AreEqual(expectedResult, result);
        }

        //Over 500 km, 2.25, pr km. With less than 12 passengers.
        [TestMethod()]
        public void TotalCost_Above500Travelled_LessThan12Passengers()
        {
            var noOfPassengers = 10;
            var distance = 550;

            var above500Distance = distance - FiveHundredDistance;
            var above100Below500Distance = distance - above500Distance - HundredDistance;

            var above500Cost = above500Distance * Above500Fee;
            var above100Below500Cost = above100Below500Distance * Above100Below500LessThan12PassengersFee;
            var hundredCost = HundredDistance * Below100Fee;

            var expectedResult = above500Cost + above100Below500Cost + hundredCost + InitialFee;
            var result = _bus.TotalCost(noOfPassengers, distance);

            Assert.AreEqual(expectedResult, result);
        }

        //Over 500 km, 2.25, pr km. With 12 or more passengers.
        [TestMethod()]
        public void TotalCost_Above500Travelled_12OrMorePassengers() {
            var noOfPassengers = 15;
            var distance = 550;

            var above500Distance = distance - FiveHundredDistance;
            var above100Below500Distance = distance - above500Distance - HundredDistance;

            var above500Cost = above500Distance * Above500Fee;
            var above100Below500Cost = above100Below500Distance * Above100Below500_12OrMorePassengersFee;
            var hundredCost = HundredDistance * Below100Fee;

            var expectedResult = above500Cost + above100Below500Cost + hundredCost + InitialFee;
            var result = _bus.TotalCost(noOfPassengers, distance);

            Assert.AreEqual(expectedResult, result);
        }
    }
}