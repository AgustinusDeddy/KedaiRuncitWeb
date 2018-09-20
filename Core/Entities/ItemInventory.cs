using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ItemInventory : BaseEntity
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Stock { get; set; }
        public Item Item { get; set; }
    }
}
