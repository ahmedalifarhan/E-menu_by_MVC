using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
namespace ProF.Models
{
    public class comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int coment_id { get; set; }
        [Required]
        public string coment_name { get; set; }
        public virtual ICollection<Registeration_USER_>? Registeration_USER_s { get; set; }



    }
}
