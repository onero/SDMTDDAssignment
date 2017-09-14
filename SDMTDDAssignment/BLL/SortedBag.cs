using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDMTDDAssignment.BLL
{
    public class SortedBag : ISortedBag
    {
        private readonly IList<int> _bag;

        public SortedBag()
        {
            _bag = new List<int>();
        }

        public void Add(int number)
        {
            _bag.Add(number);
        }

        public IList<int> GetBag()
        {
            return new List<int>(_bag);
        }

        public int Pop()
        {
            if (_bag.Count == 0) throw new ArgumentException("Unable to POP empty collection");
            // Get lowest number
            var lowestNumber = _bag.Min();
            // Remove it from bag
            _bag.Remove(lowestNumber);
            // return number
            return lowestNumber;
        }

        public int Count => _bag.Count;
    }
}