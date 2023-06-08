using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProF.Models
{
	public class Table
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int table_num { get; set; }

		public string class_ { get; set; }

		public virtual ICollection<Registeration_USER_>? Registeration_USER_s { get; set; }
	}
}
