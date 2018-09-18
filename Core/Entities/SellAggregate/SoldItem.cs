namespace Core.Entities.SellAggregate
{
    public class SoldItem : BaseEntity
    {
        public int ItemId { get; private set; }
        //store price incase the selling price change
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public Item Item { get; private set; }
        public Sell Sell { get; set; }

        private SoldItem()
        {
        }

        public SoldItem(int itemId, decimal price, int quantity)
        {
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
        }
    }
}
