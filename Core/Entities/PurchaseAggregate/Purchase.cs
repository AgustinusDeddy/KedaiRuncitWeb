using System;
using System.Collections.Generic;

namespace Core.Entities.PurchaseAggregate
{
    public class Purchase : BaseEntity
    {
        private  Purchase()
        {           
        }

        public DateTimeOffset PurchasedTime { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
