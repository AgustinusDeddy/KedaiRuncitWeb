using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.PurchaseAggregate
{
    public class PurchaseItem : BaseEntity
    {
        [Required]
        public int ItemId { get; private set; }
        [Range(0.0, Double.MaxValue, ErrorMessage = "Price must be positive number")]
        public double Price { get; private set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Quantity { get; private set; }     

        public Item Item { get; private set; }
        public Purchase Purchase { get; set; }

        private PurchaseItem()
        {        
        }

        public PurchaseItem(int itemId, double price, int quantity)
        {
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
        }
    }
}
