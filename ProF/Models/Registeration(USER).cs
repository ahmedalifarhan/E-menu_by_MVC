using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProF.Models
{
    public class Registeration_USER_
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Register_id { get; set; }
        // public int table_number { get; set; }
        [Required]
        public string fname { get; set; }

        [Required]
        public string lname { get; set; }
        [Required]
        // [CreditCard]
        // public string credit_card_number { get; set; }

        [ForeignKey(nameof(table_num))]
        public int table_num { get; set; }
        [Required]

       // [DataType(DataType.DateTime)]
        public DateTime Register_DateTime { get; set; }

       public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<comment>? comments { get; set; }
        public virtual ICollection<Table>? Tables { get; set; }

    }
}
