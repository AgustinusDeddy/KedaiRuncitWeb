using System.ComponentModel.DataAnnotations;

namespace KedaiRuncitWeb.ViewModels
{
    public class ItemCreateEditViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Stock { get; set; }
    }
}
