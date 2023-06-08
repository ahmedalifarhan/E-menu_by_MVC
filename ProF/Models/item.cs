using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace ProF.Models
{
    public enum category
    {
        menu, special_food, fast_food, offers
    }
    public class item
    {
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int item_id { get; set; }
            [Required]
            public string item_Name { get; set; }
            [Required]
            public category category { get; set; }
             [Required]
            public string item_Description { get; set; }
            [Required]
            public float item_Cost { get; set; }
        public int stars { get; set; }


        [Display(Name = "Image")]
           [DefaultValue("default.png")]
            public string item_image { get; set; }
            
            public int adminID { get; set; }
            [ForeignKey("adminID")]
        


            //لا ده جدول ال many 
        public virtual login_admin? login_admin { get; set; }




       
    }
        }

