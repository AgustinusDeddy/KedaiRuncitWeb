namespace Core.Entities
{
    public class ItemInventory : BaseEntity
    {
        public int Stock { get; set; }
        public Item Item { get; set; }
    }
}
