using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Basvuru
	{
		[Key]
		public int Basvuru_Id { get; set; }
		[ForeignKey("Ilan")]
		public int Ilan_Id { get; set; }
		public Ilan? Ilan { get; set; }
		[ForeignKey("Personel")]
		public int Personel_Id { get; set; }
		public Personel? Personel { get; set; }
		[ForeignKey("BasvuruStatu")]
		public int BasvuruStatu_Id { get; set; }
		public BasvuruStatu? BasvuruStatu { get; set; }
		public List<Belge>? Belges { get; set; }
		public List<DegerlendirmeBelge>? DegerlendirmeBelges { get; set; }
		public List<BasvuruYonlendir>? BasvuruYonlendirs { get; set; }
	}
}
