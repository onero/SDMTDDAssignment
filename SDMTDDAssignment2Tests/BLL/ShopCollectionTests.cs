using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDMTDDAssignment2.BE;
using SDMTDDAssignment2.BLL;

namespace SDMTDDAssignment2Tests.BLL
{
    [TestClass()]
    public class ShopCollectionTests
    {
        private const string NonExistingIdString = "Id doesn't exist";
        private const int NonExistingId = 999;
        private IShopCollection _shopCollection;

        private static readonly Shop MockShop = new Shop()
        {
            Id = 1,
            Name = "De4FlotteFyre",
            Address = "Home",
            Longtitude = 1,
            Latitude = 1,
            WebsiteUrl = "www.de4flottefyre.org"
        };

        [TestInitialize]
        public void InitializeVoid()
        {
            _shopCollection = new ShopCollection();
        }

        [TestMethod()]
        public void CreateTest()
        {
            var createdShop = _shopCollection.Create(MockShop);

            Assert.IsNotNull(createdShop);
        }

        [TestMethod()]
        public void ReadTest()
        {
            var createdShop = _shopCollection.Create(MockShop);

            var result = _shopCollection.Read(createdShop.Id);

            Assert.AreEqual(createdShop, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), NonExistingIdString)]
        public void ReadNonExistingShopTest()
        {
            _shopCollection.Read(NonExistingId);
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            var shops = _shopCollection.ReadAll();

            Assert.IsNotNull(shops);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var createdShop = _shopCollection.Create(MockShop);
            createdShop.Name = "Awesome shop!";

            var updatedShop = _shopCollection.Update(createdShop);

            Assert.AreEqual(createdShop, updatedShop);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), NonExistingIdString)]
        public void UpdateNonExistingShopTest()
        {
            _shopCollection.Update(MockShop);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var createdShop = _shopCollection.Create(MockShop);

            _shopCollection.Delete(createdShop.Id);

            var shops = _shopCollection.ReadAll();

            Assert.IsTrue(shops.Any() == false);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), NonExistingIdString)]
        public void DeleteNonExistingShopTest()
        {
            _shopCollection.Delete(NonExistingId);
        }

        [TestMethod()]
        public void GetShopsSortedInDistanceTest()
        {
            // Create mockshop
            var firstShop = MockShop;

            // Create secondshop, with modified longtitude
            var secondShop = new Shop()
            {
                Id = 2,
                Name = "Test",
                Address = "Secret",
                Latitude = 1,
                Longtitude = 2,
                WebsiteUrl = "www.test.com"
            };
            _shopCollection.Create(secondShop);

            // Create coordinate to check against
            const int latitude = 0;
            const int longtitude = 0;
            // Expected result with closest shop first in list
            var expectedResult = new List<Shop>()
            {
                firstShop,
                secondShop
            };
            // Actual result
            var result = _shopCollection.GetShopsSortedInDistance(latitude, longtitude).ToList();

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        public void GetShopsInSpecifiedAreaTest()
        {
            // Create mockshop
            var firstShop = _shopCollection.Create(MockShop);

            // Create secondshop, with modified longtitude
            var secondShop = MockShop;
            secondShop.Longtitude = 2;
            _shopCollection.Create(secondShop);

            // Create start coordinates to check against
            const int startLatitude = 0;
            const int startLongtitude = 0;

            // Create end coordinates to check against
            const int endLatitude = 1;
            const int endLongtitude = 1;

            // Expected result with closest shop first in list
            var expectedResult = new List<Shop>()
            {
                firstShop
            };
            // Actual result
            var result = _shopCollection.GetShopsInSpecifiedArea(startLatitude, startLongtitude, endLatitude, endLongtitude);

            Assert.AreEqual(expectedResult, result);
        }
    }
}