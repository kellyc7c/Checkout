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
        [TestCase("A",50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void ScanOneItemReturnsCorrectPrice(string item, int expectedPrice)
        {
            var checkout = new Checkout();

            int price = checkout.Scan(item);

            Assert.AreEqual(expectedPrice, price);
        }
    }
}
