using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDMTDDAssignment.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMTDDAssignment.BLL.Tests {
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

            var expectedResult = 5;
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