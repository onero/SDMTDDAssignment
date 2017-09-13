using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDMTDDAssignment2.BE;

namespace SDMTDDAssignment2.BLL
{
    public interface IShopCollection
    {
        /// <summary>
        /// Creates a new shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>Shop</returns>
        Shop Create(Shop shop);

        /// <summary>
        /// Read all shops
        /// </summary>
        /// <returns>Collection of shops</returns>
        IEnumerable<Shop> ReadAll();

        /// <summary>
        /// Get Shop with parsed Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Shop with the parsed Id.</returns>
        /// <remarks>Should throw an exception if the shopCollection is found.</remarks>
        Shop Read(int id);

        /// <summary>
        /// Updates the shopCollection with the parsed id.
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>IShopCollection</returns>
        /// <remarks>Should throw an exception if the shopCollection is found.</remarks>
        Shop Update(Shop shop);

        /// <summary>
        /// Deletes the shopCollection with the parsed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if deleted</returns>
        bool Delete(int id);

        /// <summary>
        /// Returns an IEnumerable with all shopCollection sorted in distance from the parsed GPS-coordinate.
        /// The one closest should be first in the IEnumerable.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>Collection of IShopCollection</returns>
        IEnumerable<Shop> GetShopsSortedInDistance(int latitude, int longitude);

        /// <summary>
        /// Returns an IEnumerable with all shopCollections located within a rectangle of the two parsed GPS-coordinates.
        /// </summary>
        /// <param name="firstLatitude"></param>
        /// <param name="firstLongitude"></param>
        /// <param name="secondLatitude"></param>
        /// <param name="secondLongitude"></param>
        /// <returns>Collection of IShopCollection</returns>
        IEnumerable<Shop> GetShopsInSpecifiedArea(int firstLatitude, int firstLongitude,
            int secondLatitude, int secondLongitude);
    }
}