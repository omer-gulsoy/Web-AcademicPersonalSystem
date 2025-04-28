using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class BilimselToplanti
	{
		[Key]
		public int BilimselToplanti_Id { get; set; }
		public string? BildiriIsmi { get; set; }
		public string? KonferansIsmi { get; set; }
		public string? YapildigiYer { get; set; }
		public int SayfaSayi { get; set; }
		public DateOnly Tarih { get; set; }
		public int YazarSayi { get; set; }
		public float Puan { get; set; }
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
