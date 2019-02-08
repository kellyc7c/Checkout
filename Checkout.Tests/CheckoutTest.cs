using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Checkout.Tests
{
    [TestFixture]
    public class CheckoutTest
    {
        private Dictionary<char, int> _prices = new Dictionary<char, int>() {
            { 'A', 50 },
            { 'B', 30 },
            { 'C', 20 },
            { 'D', 15 } };

        private List<Offer> _offers = new List<Offer>()
        {
            new Offer('A', 3, 20),
            new Offer('B', 2, 15)
        };

        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void ScanOneItemReturnsCorrectPrice(string item, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(item);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("AA", 100)]
        [TestCase("CC", 40)]
        [TestCase("DD", 30)]
        public void ScanTwoOfTheSameItemReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("AB", 80)]
        [TestCase("BC", 50)]
        [TestCase("CD", 35)]
        [TestCase("DA", 65)]
        public void ScanTwoDifferentItemsReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("ABD", 95)]
        [TestCase("BCA", 100)]
        [TestCase("CDB", 65)]
        [TestCase("DAB", 95)]
        public void ScanThreeDifferentItemsReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("ABCD", 115)]
        [TestCase("AABCD", 165)]
        [TestCase("BADCDA", 180)]
        public void ScanMultipleDifferentItemsReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("AAA", 130)]
        public void CheckDiscountApplysToTotalForThreeOfTheSameItemUsing_offers(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("BACCADA", 215)]
        [TestCase("BBACCADAABAA", 390)]
        public void CheckDiscountApplysForOffersWhenMultipleDifferntAreScanned(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        public void InvalidItemsInScannedInputAreIgnoredWhenCalculatingPrice()
        {
            var checkout = new Checkout(_prices, _offers);

            int price = checkout.Scan("AGB5CDV");

            Assert.AreEqual(115, price);
        }
    }
}
