using System;
using Core.Entities.SellAggregate;
using NUnit.Framework;

namespace KedaiRuncitWeb.UnitTests.Entities
{
    [TestFixture]
    public class SoldItemTests
    {
        [Test]
        public void AssignPrice_NegativeValue_ReturnError()
        {
            Assert.That(() => new SoldItem(1, -1.5, 1),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void AssignPrice_CorrectValue_ReturnItem()
        {
            SoldItem item = new SoldItem(1, 1.5, 1);

            Assert.That(item.Price, Is.EqualTo(1.5));
            Assert.That(item.Quantity, Is.EqualTo(1));
        }
    }
}
