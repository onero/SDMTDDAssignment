using System;
using System.Collections.Generic;
using static SDMTDDAssignment3.BLL.BusFees;
using SDMTDDAssignment3.BLL;
using Xunit;

namespace SDMTDDAssignment3XunitTests
{

    public class BusFareShould
    {
        private readonly IBusFare _bus;

        public BusFareShould()
        {
            _bus = new BusFare();
        }

        [Theory]
        [InlineData(12, 0, InitialFee + (0 * Below100Fee))]
        [InlineData(12, 50, InitialFee + (50 * Below100Fee))]
        [InlineData(11, 100, InitialFee + (99 * Below100Fee) + Above100Below500LessThan12PassengersFee)]
        [InlineData(12, 100, InitialFee + (99 * Below100Fee) + Above100Below50012OrMorePassengersFee)]
        [InlineData(11, 250, InitialFee + (99 * Below100Fee) + (250 - 99) * Above100Below500LessThan12PassengersFee)]
        [InlineData(12, 250, InitialFee + (99 * Below100Fee) + (250 - 99) * Above100Below50012OrMorePassengersFee)]
        [InlineData(11, 500, InitialFee + (99 * Below100Fee) + (499 - 99) * Above100Below500LessThan12PassengersFee + Above500Fee)]
        [InlineData(12, 500, InitialFee + (99 * Below100Fee) + (499 - 99) * Above100Below50012OrMorePassengersFee + Above500Fee)]
        public void ReturnTotalCost(int noOfPassengers, int kilometers, double expected)
        {
            var result = _bus.TotalCost(noOfPassengers, kilometers);

            Assert.Equal(expected, result);
        }
    }
}