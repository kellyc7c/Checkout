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
        [Test]
        public void ScanOneItemReturnsCorrectPrice()
        {
            var checkout = new Checkout();

            int price = checkout.Scan("A");

            Assert.AreEqual(50, price);
        }
    }
}
