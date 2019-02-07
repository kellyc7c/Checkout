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
        private List<Tuple<string, int, int>> _offers;

        public Checkout(Dictionary<string, int> prices, List<Tuple<string, int, int>> offers)
        {
            _prices = prices;
            _offers = offers;
        }

        public int Scan(string items)
        {
            int total = GetTotal(items);
            total = ApplyDiscounts(items, total);

            return total;
        }

        private int GetTotal(string items)
        {
            int total = 0;

            foreach (char item in items)
            {
                total += _prices[item.ToString()];
            }

            return total;
        }

        private int ApplyDiscounts(string items, int total)
        {
            foreach (Tuple<string, int, int> offer in _offers)
            {
                int totalItems = 0;
                foreach (char item in items)
                {
                    if (item.ToString() == offer.Item1)
                    {
                        totalItems++;
                    }

                    
                }
                total -= totalItems / offer.Item2 * offer.Item3;
            }
            return total;
        }
    }
}
