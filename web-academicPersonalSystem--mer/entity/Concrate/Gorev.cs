using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Gorev
	{
		[Key]
		public int Gorev_Id { get; set; }
		public string? Birim { get; set; }
		public int? Yil { get; set; }
		public bool? Puan { get; set; }
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
