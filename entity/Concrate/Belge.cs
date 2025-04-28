using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Belge
	{
		[Key]
		public int Belge_Id { get; set; }
		public string? Isim { get; set; }
		public string? URL { get; set; }
		[ForeignKey("Basvuru")]
		public int Basvuru_Id { get; set; }
		public Basvuru? Basvuru { get; set; }
	}
}
