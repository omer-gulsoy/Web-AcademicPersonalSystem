using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Makale
	{
		[Key]
		public int Makale_Id { get; set; }
		public string? Isim { get; set; }
		public string? DergiIsim { get; set; }
		public string? CiltNo { get; set; }
		public int SayfaSayi { get; set; }
		public int BasimYili { get; set; }
		public int YazarSayi { get; set; }
		public double Puan { get; set; }
		[ForeignKey("Personel")]
		public int Personel_Id { get; set; }
		public Personel? Personel { get; set; }
		[ForeignKey("Puanlama")]
		public int Puanlama_Id { get; set; }
		public Puanlama? Puanlama { get; set; }
		[ForeignKey("Katsayi")]
		public int Katsayi_Id { get; set; }
		public Katsayi? Katsayi { get; set; }
	}
}
