using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProF.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_num { get; set; }

        [ForeignKey(nameof(Register_id))]
        public int Register_id { get; set; }
        [ForeignKey(nameof(Recipes_Num))
]
        public string Recipes_Num { get; set; }

        [Required]
       
       // [DataType(DataType.DateTime)]
        public string Order_DateTime { get; set; }
        [Required]
        public int Quantity_of_each_recipe { get; set; }

        public virtual Registeration_USER_ Registeration_USER_ { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
