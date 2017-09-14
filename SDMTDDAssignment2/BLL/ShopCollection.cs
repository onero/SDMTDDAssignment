using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMTDDAssignment2.BE;

namespace SDMTDDAssignment2.BLL
{
    public class ShopCollection : IShopCollection
    {
        private readonly List<Shop> _shops;

        public ShopCollection()
        {
            _shops = new List<Shop>();
        }

        public Shop Create(Shop shop)
        {
            _shops.Add(shop);
            return shop;
        }

        public IEnumerable<Shop> ReadAll()
        {
            return _shops;
        }

        public Shop Read(int id)
        {
            var shop = _shops.FirstOrDefault(s => s.Id == id);
            if(shop == null) throw new ArgumentException();
            return shop;
        }

        public Shop Update(Shop shop)
        {
            var shopToEdit = Read(shop.Id);
            shopToEdit.Address = shop.Address;
            shopToEdit.Name = shop.Name;
            shopToEdit.WebsiteUrl = shop.WebsiteUrl;
            shopToEdit.Latitude = shop.Latitude;
            shopToEdit.Longtitude = shop.Longtitude;
            return shopToEdit;
        }

        public IEnumerable<Shop> GetShopsSortedInDistance(int targetLatitude, int targetLongitude)
        {
            var shopsAndTheirDistanceFromTarget = new Dictionary<Shop, double>();

            foreach (var shop in _shops)
            {
                var distanceFromTarget =
                    FindDistanceBetweenTwoCoordinates(targetLatitude, targetLongitude, shop.Latitude, shop.Longtitude);
                shopsAndTheirDistanceFromTarget.Add(shop, distanceFromTarget);
            }

            var sortedShops = new List<Shop>();
            while (shopsAndTheirDistanceFromTarget.Any())
            {
                var lowestValue = shopsAndTheirDistanceFromTarget.Min(v => v.Value);
                var keyValuePair = shopsAndTheirDistanceFromTarget.FirstOrDefault(kvp => kvp.Value.Equals(lowestValue));
                shopsAndTheirDistanceFromTarget.Remove(keyValuePair.Key);
                sortedShops.Add(keyValuePair.Key);
            }

            return sortedShops;
        }

        public bool Delete(int id)
        {
            return _shops.Remove(Read(id));
        }

        public IEnumerable<Shop> GetShopsInSpecifiedArea(int firstLatitude, int firstLongitude, int secondLatitude,
            int secondLongitude)
        {
            throw new NotImplementedException();

            FindWidthAndLengthOfRectangel(out var width, out var length, firstLatitude, firstLongitude, secondLatitude, secondLongitude);

            var shopsInSpecifiedArea = new List<Shop>();

            foreach (var shop in _shops)
            {
                var latitude = shop.Latitude;
                var longitude = shop.Longtitude;
                var distanceToFirstCorner =
                    FindDistanceBetweenTwoCoordinates(firstLatitude, firstLongitude, latitude, longitude);
                var distanceToSecondCorner =
                    FindDistanceBetweenTwoCoordinates(secondLatitude, secondLongitude, latitude, longitude);
                if (distanceToFirstCorner <= width 
                            && distanceToFirstCorner <= length 
                            && distanceToSecondCorner <= width 
                            && distanceToSecondCorner <= length)
                {
                    shopsInSpecifiedArea.Add(shop);
                }
            }

            return shopsInSpecifiedArea;
        }

        /// <summary>
        /// Finds the distance between the two objects by using the mathematical distanceFormula |AB| = sqrt((x2-x1)^2+(y2-y1)^2).
        /// </summary>
        /// <param name="x1">Latitude A</param>
        /// <param name="y1">Longittude A</param>
        /// <param name="x2">Longittude B</param>
        /// <param name="y2">Longittude B</param>
        /// <returns>distance between two coordinates as a double</returns>
        private double FindDistanceBetweenTwoCoordinates(int x1, int y1, int x2, int y2)
        {
            var xPow = Math.Pow(x2 - x1, 2);
            var yPow = Math.Pow(y2 - y1, 2);
            var distance = Math.Sqrt(xPow + yPow);
            return distance;
        }

        private void FindWidthAndLengthOfRectangel(out int width, out int length, int x1, int y1, int x2, int y2)
        {
            width = x1 - x2;
            if (width < 0) width *= -1;

            length = y1 - y2;
            if (length < 0) length *= -1;
        }

    }
}