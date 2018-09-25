using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.SellAggregate
{
    public class Sell : BaseEntity
    {
        private Sell()
        {
        }

        public Sell(List<SoldItem> items)
        {
            SoldItems = items;     
        }

        public DateTimeOffset SoldTime { get; set; }
        public double TotalAmount => CalculateTotal();
        public ICollection<SoldItem> SoldItems { get; private set; }

        public double CalculateTotal()
        {
            return SoldItems.Sum(i => i.Price * i.Quantity);
        }
    }
}
