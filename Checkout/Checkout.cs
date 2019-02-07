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

        public Checkout(Dictionary<string, int> prices, List<Offer> offers)
        {
            _prices = prices;
            _offers = offers;
        }

        public int Scan(string items)
        {
            int total = GetTotal(items);
            total -= GetDiscounts(items);

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

        private int GetDiscounts(string items)
        {
            int totalDiscount = 0;

            foreach (Offer offer in _offers)
            {
                totalDiscount += GetSingleDiscount(items, offer);
            }
            return totalDiscount;
        }

        private int GetSingleDiscount(string items, Offer offer)
        {
            int numberOfOfferItemsScanned = 0;

            foreach (char item in items)
            {
                if (item.ToString() == offer.ItemID)
                {
                    numberOfOfferItemsScanned++;
                }
            }

            return numberOfOfferItemsScanned / offer.NumberOfItemsForOffer * offer.Discount;
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
