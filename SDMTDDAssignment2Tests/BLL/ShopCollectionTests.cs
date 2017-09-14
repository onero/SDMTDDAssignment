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

        private static readonly Shop Broen = new Shop()
        {
            Id = 1,
            Name = "Broen",
            Address = "Exnersgade 20, 6700 Esbjerg",
            Longtitude = 55.465522,
            Latitude = 8.457322,
            WebsiteUrl = "http://broenshopping.dk/"
        };

        [TestInitialize]
        public void InitializeVoid()
        {
            _shopCollection = new ShopCollection();
        }

        [TestMethod()]
        public void CreateTest()
        {
            var createdShop = _shopCollection.Create(Broen);

            Assert.IsNotNull(createdShop);
        }

        [TestMethod()]
        public void ReadTest()
        {
            var createdShop = _shopCollection.Create(Broen);

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
            var createdShop = _shopCollection.Create(Broen);
            createdShop.Name = "Awesome shop!";

            var updatedShop = _shopCollection.Update(createdShop);

            Assert.AreEqual(createdShop, updatedShop);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), NonExistingIdString)]
        public void UpdateNonExistingShopTest()
        {
            _shopCollection.Update(Broen);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var createdShop = _shopCollection.Create(Broen);

            var deleted = _shopCollection.Delete(createdShop.Id);

            //var shops = _shopCollection.ReadAll();

            Assert.IsTrue(deleted);
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
            var broen = Broen;

            // Create secondshop, with modified longtitude
            var sevenEleven = new Shop()
            {
                Id = 2,
                Name = "Shell/7-Eleven Esbjerg",
                Address = "Stormgade 206 6700 Esbjerg",
                Latitude = 55.487224,
                Longtitude = 8.449184,
                WebsiteUrl = "http://www.7-eleven.dk/"
            };
            _shopCollection.Create(sevenEleven);
            _shopCollection.Create(broen);

            // Check against EASV address
            const double latitude = 55.48573500000001;
            const double longtitude = 8.456728999999996;
            // Expected result with closest shop first in list
            var expectedResult = new List<Shop>()
            {
                sevenEleven,
                broen
            };
            // Actual result
            var result = _shopCollection.GetShopsSortedInDistance(latitude, longtitude).ToList();

            Assert.AreEqual(expectedResult[0], result[0]);
            
        }

        [TestMethod()]
        public void GetShopsInSpecifiedAreaTest()
        {
            // Create mockshop
            var firstShop = _shopCollection.Create(Broen);

            // Create secondshop, with modified longtitude
            var secondShop = Broen;
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
            var result = _shopCollection.GetShopsInSpecifiedArea(startLatitude, startLongtitude, endLatitude, endLongtitude).ToList();

            Assert.AreEqual(expectedResult[0], result[0]);
        }
    }
}