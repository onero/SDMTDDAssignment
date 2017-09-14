using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDMTDDAssignment.BLL;

namespace SDMTDDAssignmentTests.BLL
{
    [TestClass()]
    public class SortedBagTests
    {
        private ISortedBag _sortedBag;


        [TestInitialize]
        public void Initialize()
        {
            _sortedBag = new SortedBag();
        }

        [TestMethod()]
        public void BagIsIncreasedTest()
        {
            _sortedBag.Add(5);

            var expectedResult = 1;
            var result = _sortedBag.Count;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void NumberIsAddedTest()
        {
            var numberToAdd = 5;
            _sortedBag.Add(numberToAdd);
            
            var result = _sortedBag.GetBag()[0];

            Assert.AreEqual(numberToAdd, result);
        }

        [TestMethod()]
        public void BagEmptyTest()
        {
            var expectedResult = 0;
            var result = _sortedBag.Count;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void PopReturnsLowestTest()
        {
            _sortedBag.Add(7);
            _sortedBag.Add(2);
            _sortedBag.Add(10);

            var result = _sortedBag.Pop();
            var expectedResult = 2;

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        public void PopReturnsCountTest()
        {
            _sortedBag.Add(7);
            _sortedBag.Add(2);
            _sortedBag.Add(10);

            _sortedBag.Pop();
            var expectedResult = 2;
            var result = _sortedBag.Count;

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Unable to POP empty collection")]
        public void PopEmptyThrowsExceptionTest()
        {
            _sortedBag.Pop();
        }
    }
}