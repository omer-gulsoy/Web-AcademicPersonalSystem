using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Personel_Role
	{
		[Key]
		public int Personel_Role_Id { get; set; }
		[ForeignKey("Personel")]
		public int Personel_Id { get; set; }
		public Personel? Personel { get; set; }
		[ForeignKey("Rol")]
		public int Rol_Id { get; set; }
		public Rol? Rol { get; set; }
	}
}
