using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class DegerlendirmeBelge
	{
		[Key]
		public int DegerlendirmeBelge_Id { get; set; }
		public string? DosyaYolu { get; set; }
		[ForeignKey("Basvuru")]
		public int Basvuru_Id { get; set; }
		public Basvuru? Basvuru { get; set; }
		[ForeignKey("Personel")]
		public int Personel_Id { get; set; }
		public Personel? Personel { get; set; }
	}
}
