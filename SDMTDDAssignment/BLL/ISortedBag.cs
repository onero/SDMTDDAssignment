using System.Collections.Generic;

namespace SDMTDDAssignment.BLL
{
    public interface ISortedBag
    {
        // Add integer
        void Add(int numbers);

        // Get Bag
        IList<int> GetBag();

        // Retrieve and remove smallest integer
        int Pop();

        // Retrieve the number of integers
        int Count { get; }
    }
}