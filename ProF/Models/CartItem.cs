using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProF.Models
{
    public class CartItem
    {

        [Key]
        public int CartItemId { get; set; }

        [Display(Name = "Image")]
        [DefaultValue("default.png")]
        public string? item_image { get; set; }
        public string? ItemName { get; set; }
        public float item_Cost { get; set; }
        [ForeignKey("item_image")]
        public int Quantity { get; set; }
    }
}
