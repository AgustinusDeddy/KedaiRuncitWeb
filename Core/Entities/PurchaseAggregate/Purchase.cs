using System;
using System.Collections.Generic;

namespace Core.Entities.PurchaseAggregate
{
    public class Purchase : BaseEntity
    {
        private  Purchase()
        {           
        }

        public DateTimeOffset PurchasedDate { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
