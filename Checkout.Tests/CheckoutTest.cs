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
        private Dictionary<string, int> _prices = new Dictionary<string, int>() {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 } };

        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void ScanOneItemReturnsCorrectPrice(string item, int expectedPrice)
        {
            var checkout = new Checkout(_prices);

            int price = checkout.Scan(item);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("AA", 100)]
        [TestCase("BB", 60)]
        [TestCase("CC", 40)]
        [TestCase("DD", 30)]
        public void ScanTwoOfTheSameItemReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("AB", 80)]
        [TestCase("BC", 50)]
        [TestCase("CD", 35)]
        [TestCase("DA", 65)]
        public void ScanTwoDifferentItemsReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("ABD", 95)]
        [TestCase("BCA", 100)]
        [TestCase("CDB", 65)]
        [TestCase("DAB", 95)]
        public void ScanThreeDifferentItemsReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }

        [TestCase("ABCD", 115)]
        [TestCase("AABCD", 165)]
        [TestCase("BADCDB", 160)]
        public void ScanMultipleDifferentItemsReturnsCorrectPrice(string items, int expectedPrice)
        {
            var checkout = new Checkout(_prices);

            int price = checkout.Scan(items);

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
