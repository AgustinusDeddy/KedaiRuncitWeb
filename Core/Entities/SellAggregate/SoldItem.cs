using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.SellAggregate
{
    public class SoldItem : BaseEntity
    {
        [Required]
        public int ItemId { get; private set; }
        //store price incase the selling price change
        [Range(0.0, Double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Price { get; private set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Quantity { get; private set; }

        public Item Item { get; private set; }
        public Sell Sell { get; set; }

        private SoldItem()
        {
        }

        public SoldItem(int itemId, double price, int quantity)
        {
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
        }
    }
}
