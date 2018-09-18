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

        public DateTimeOffset SoldTime { get; set; }
        public decimal TotalAmount => CalculateTotal();
        public ICollection<SoldItem> SoldItems { get; set; }

        private decimal CalculateTotal()
        {
            return SoldItems.Sum(i => i.Price * i.Quantity);
        }
    }
}
