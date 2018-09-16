namespace Core.Entities.PurchaseAggregate
{
    public class PurchaseItem : BaseEntity
    {
        public int ItemId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }     

        public Item Item { get; private set; }
        public Purchase Purchase { get; set; }

        private PurchaseItem()
        {        
        }

        public PurchaseItem(int itemId, decimal price, int quantity)
        {
            ItemId = itemId;
            Price = price;
            Quantity = quantity;
        }
    }
}
