using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout
    {
        private Dictionary<string, int> _prices;

        public Checkout(Dictionary<string, int> prices)
        {
            _prices = prices;
        }

        public int Scan(string items)
        {
            int total = 0;

            foreach (char item in items)
            {
                total += _prices[item.ToString()];
            }

            return total;
        }
    }
}
