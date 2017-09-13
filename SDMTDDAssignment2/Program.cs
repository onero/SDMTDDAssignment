using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SDMTDDAssignment2.BE;
using SDMTDDAssignment2.BLL;

namespace SDMTDDAssignment2
{
    public class Program
    {
        private static readonly Shop MockShop = new Shop() {
            Id = 1,
            Name = "De4FlotteFyre",
            Address = "Home",
            Longtitude = 1,
            Latitude = 1,
            WebsiteUrl = "www.de4flottefyre.org"
        };

        public static void Main(string[] args)
        {
            var _shopCollection = new ShopCollection();

            // Create mockshop
            var firstShop = _shopCollection.Create(MockShop);

            // Create secondshop, with modified longtitude
            var secondShop = new Shop() {
                Id = 2,
                Name = "Test",
                Address = "Secret",
                Latitude = 1,
                Longtitude = 2,
                WebsiteUrl = "www.test.com"
            };
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
        }
    }
}