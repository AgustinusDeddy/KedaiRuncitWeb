using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.SellAggregate
{
    public class SellItem : BaseEntity
    {
        private SellItem()
        {
        }

        public SellItem(int itemId, decimal price)
        {
            ItemId = itemId;
            Price = price;
        }

        [Required]
        public int ItemId { get; private set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Price { get; private set; }

        public Item Item { get; private set; }
    }
}
