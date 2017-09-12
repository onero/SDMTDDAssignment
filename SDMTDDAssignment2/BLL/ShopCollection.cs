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
        public Shop Create(Shop shop)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shop> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Shop Read(int id)
        {
            throw new NotImplementedException();
        }

        public Shop Update(Shop shop)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IShopCollection> GetShopsSortedInDistance(int latitude, int longitude)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IShopCollection> GetShopsInSpecifiedArea(int firstLatitude, int firstLongitude, int secondLatitude, int secondLongitude)
        {
            throw new NotImplementedException();
        }
    }
}