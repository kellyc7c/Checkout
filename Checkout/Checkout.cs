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
        private List<Offer> _offers;

        public Checkout(Dictionary<string, int> prices, List<Tuple<string, int, int>> offers)
        {
            _prices = prices;
            _offers = new List<Offer>();
            foreach (Tuple<string, int, int> offer in offers)
            {
                _offers.Add(new Offer(offer.Item1, offer.Item2, offer.Item3));
            }
        }

        public Checkout(Dictionary<string, int> prices, List<Offer> offers)
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
            foreach (Offer offer in _offers)
            {
                int totalItems = 0;
                foreach (char item in items)
                {
                    if (item.ToString() == offer.ItemID)
                    {
                        totalItems++;
                    }

                    
                }
                total -= totalItems / offer.NumberOfItemsForOffer * offer.Discount;
            }
            return total;
        }
    }

    public class Offer
    {
        public string ItemID { get; }
        public int NumberOfItemsForOffer { get; }
        public int Discount { get; }

        public Offer(string itemID, int numberOfItemsForOffer, int discount)
        {
            this.ItemID = itemID;
            this.NumberOfItemsForOffer = numberOfItemsForOffer;
            this.Discount = discount;
        }
    }
}
