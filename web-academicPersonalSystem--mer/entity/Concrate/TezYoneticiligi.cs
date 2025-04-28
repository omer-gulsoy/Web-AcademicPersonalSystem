using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class TezYoneticiligi
	{
		[Key]
		public int TezYoneticiligi_Id { get; set; }
		public string? Isim { get; set; }
		public string? Enstutu { get; set; }
		public int? Yil { get; set; }
		public double? Puan { get; set; }
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
