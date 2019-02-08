using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout
    {
        readonly private Dictionary<char, int> _prices;
        readonly private List<Offer> _offers;

        public Checkout(Dictionary<char, int> prices, List<Offer> offers)
        {
            _prices = prices;
            _offers = offers;
        }

        public int Scan(string items)
        {
            var numberOfEachItemScanned = ParseInput(items);
            int total = GetTotalPrice(numberOfEachItemScanned);
            total -= GetDiscounts(numberOfEachItemScanned);

            return total;
        }

        private Dictionary<char, int> ParseInput(string items)
        {
            var numberOfEachItemScanned = new Dictionary<char, int>();

            foreach (char item in items)
            {
                if (!_prices.ContainsKey(item)) continue;

                if (numberOfEachItemScanned.ContainsKey(item))
                {
                    numberOfEachItemScanned[item]++;
                }
                else
                {
                    numberOfEachItemScanned[item] = 1;
                }
            }

            return numberOfEachItemScanned;
        }

        private int GetTotalPrice(Dictionary<char, int> numberOfEachItemScanned)
        {
            int total = 0;

            foreach (var item in numberOfEachItemScanned)
            {

                total += _prices[item.Key] * item.Value;
            }

            return total;
        }

        private int GetDiscounts(Dictionary<char, int> numberOfEachItemScanned)
        {
            int totalDiscount = 0;

            foreach (Offer offer in _offers)
            {
                totalDiscount += GetSingleDiscount(numberOfEachItemScanned, offer);
            }
            return totalDiscount;
        }

        private int GetSingleDiscount(Dictionary<char, int> numberOfEachItemScanned, Offer offer)
        {
            int numberOfOfferItemsScanned;

            if (numberOfEachItemScanned.ContainsKey(offer.ItemID))
            {
                numberOfOfferItemsScanned = numberOfEachItemScanned[offer.ItemID];
            }
            else
            {
                numberOfOfferItemsScanned = 0;
            }
            

            return numberOfOfferItemsScanned / offer.NumberOfItemsForOffer * offer.Discount;
        }
    }

    public class Offer
    {
        public char ItemID { get; }
        public int NumberOfItemsForOffer { get; }
        public int Discount { get; }

        public Offer(char itemID, int numberOfItemsForOffer, int discount)
        {
            this.ItemID = itemID;
            this.NumberOfItemsForOffer = numberOfItemsForOffer;
            this.Discount = discount;
        }
    }
}
