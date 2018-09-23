using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Item : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public ItemInventory Inventory { get; set; }

    }
}
