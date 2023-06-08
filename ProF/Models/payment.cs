using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProF.Models
{

    public enum t_p
    {
        cash, visa
    }


    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Payment_Id { get; set; }
        [Required]
        public t_p t_p { get; set; }


        public virtual ICollection<Registeration_USER_>? Registeration_USER_s { get; set; }


    }
}
