using System.ComponentModel.DataAnnotations;

namespace ProF.Models
{
    public class Cart
    {



        [Key]
        public int CartId { get; set; }
        public int RegisterId { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}
