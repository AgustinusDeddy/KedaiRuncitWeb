namespace Core.Entities.SellAggregate
{
    public class SellItem : BaseEntity
    {
        public int ItemId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public Item Item { get; private set; }
        public Sell Sell { get; set; }

        private SellItem()
        {
        }

        public SellItem(int itemId, decimal price, int quantity)
        {
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
        }
    }
}
