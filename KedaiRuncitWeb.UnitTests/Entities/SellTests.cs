using System;
using System.Collections.Generic;
using Core.Entities.SellAggregate;
using NUnit.Framework;

namespace KedaiRuncitWeb.UnitTests.Entities
{
    [TestFixture]
    public class SellTests
    {
        [Test]
        public void CalculateTotal_NullItems_ReturnError()
        {
            Sell sell = new Sell(null);

            Assert.That(() => sell.CalculateTotal(),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CalculateTotal_NoItems_ReturnZero()
        {
            Sell sell = new Sell(new List<SoldItem>());

            var result = sell.TotalAmount;

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotal_HasItems_ReturnTotalAmount()
        {
            List<SoldItem> items = new List<SoldItem>
            {
                new SoldItem(1, 2, 1),
                new SoldItem(1, 2.50, 3)
            };

            Sell sell = new Sell(items);

            var result = sell.TotalAmount;

            Assert.That(result, Is.EqualTo(9.5));
        }
    }
}
