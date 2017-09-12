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
        private List<Shop> _shops;

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
            return _shops.FirstOrDefault(s => s.Id == id);
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

        public bool Delete(int id)
        {
            return _shops.Remove(Read(id));
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