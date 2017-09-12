using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMTDDAssignment2.BLL
{
    public class ShopCollection : IShopCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebsiteUrl { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public ShopCollection Create(ShopCollection shopCollection)
        {
            throw new NotImplementedException();
        }

        public ShopCollection Read(int id)
        {
            throw new NotImplementedException();
        }

        public ShopCollection Update(ShopCollection shopCollection)
        {
            throw new NotImplementedException();
        }

        public ShopCollection Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopCollection> GetShopsSortedInDistance(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopCollection> GetShopsInSpecifiedArea(string firstLatitude, string firstLongitude, string secondLatitude,
            string secondLongitude)
        {
            throw new NotImplementedException();
        }
    }
}