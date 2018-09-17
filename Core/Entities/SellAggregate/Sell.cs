using System;
using System.Collections.Generic;
using Core.Entities.PurchaseAggregate;

namespace Core.Entities.SellAggregate
{
    public class Sell : BaseEntity
    {
        private Sell()
        {
        }

        public DateTimeOffset SoldTime { get; set; }
        public ICollection<SellItem> SellItems { get; set; }
    }
}
