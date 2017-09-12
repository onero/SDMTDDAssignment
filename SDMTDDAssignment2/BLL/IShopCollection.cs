using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMTDDAssignment2.BLL
{
    public interface IShopCollection
    {
        int Id { set; }
        string Name { get; set; }
        string Address { get; set; }
        string WebsiteUrl { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }

        /// <summary>
        /// Creates a new shopCollection.
        /// Returns the new shopCollection.
        /// </summary>
        /// <param name="shopCollection"></param>
        /// <returns></returns>
        ShopCollection Create(ShopCollection shopCollection);

        /// <summary>
        /// Returns the shopCollection with the parsed Id.
        /// Should throw an exception if no shopCollection is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShopCollection Read(int id);

        /// <summary>
        /// Updates the shopCollection with the parsed id.
        /// Should throw an exception if the shopCollection is found.
        /// </summary>
        /// <param name="shopCollection"></param>
        /// <returns></returns>
        ShopCollection Update(ShopCollection shopCollection);

        /// <summary>
        /// Deletes the shopCollection with the parsed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShopCollection Delete(int id);

        /// <summary>
        /// Returns an IEnumerable with all shopCollection sorted in distance from the parsed GPS-coordinate.
        /// The one closest should be first in the IEnumerable.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        IEnumerable<ShopCollection> GetShopsSortedInDistance(string latitude, string longitude);

        /// <summary>
        /// Returns an IEnumerable with all shopCollections located within a rectangle of the two parsed GPS-coordinates.
        /// </summary>
        /// <param name="firstLatitude"></param>
        /// <param name="firstLongitude"></param>
        /// <param name="secondLatitude"></param>
        /// <param name="secondLongitude"></param>
        /// <returns></returns>
        IEnumerable<ShopCollection> GetShopsInSpecifiedArea(string firstLatitude, string firstLongitude,
            string secondLatitude, string secondLongitude);
    }
}