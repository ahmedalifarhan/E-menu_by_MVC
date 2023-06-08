using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProF.Models
{
    public class login_admin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int admin_id { get; set; }
        // [ForeignKey(nameof(item_id))]

        //  public int item_id { get; set; }

        // public login_admin? login_admin { get; set; }

        //  [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9.]+$",ErrorMessage ="not vaild email")]
        [RegularExpression(@"^aisha@123yahoo\.com", ErrorMessage = "not vaild email")]
//رساله الغلط مش بتتعرض
        public string email { get; set; }


        [RegularExpression(@"^aishaE@22", ErrorMessage = "not vaild password")]
        public string passward { get; set; }
       

        public virtual ICollection<item>? Items { get; set; }
       

    }
}
