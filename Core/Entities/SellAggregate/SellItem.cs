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

        public int ItemId { get; private set; }
        public decimal Price { get; private set; }

        public Item Item { get; private set; }
    }
}
