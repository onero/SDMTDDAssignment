using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDMTDDAssignment.BLL;

namespace SDMTDDAssignmentTests.BLL {
    [TestClass()]
    public class SortedBagTests {
        private ISortedBag _sortedBag;


        [TestInitialize]
        public void Initialize() {
            _sortedBag = new SortedBag();
        }

        [TestMethod()]
        public void AddTest() {
            _sortedBag.Add(5);

            var expectedResult = 1;
            var result = _sortedBag.Count;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void PopTest() {
            _sortedBag.Add(7);
            _sortedBag.Add(2);
            _sortedBag.Add(10);

            var result = _sortedBag.Pop();
            var expectedResult = 2;
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}