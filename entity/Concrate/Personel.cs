using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Personel
	{
		[Key]
		public int Personel_Id { get; set; }
		public string? Isim { get; set; }
		public string? Soyisim { get; set; }
		public string? TC { get; set; }
		public string? Eposta { get; set; }
		public string? Telefon { get; set; }
		public bool Status { get; set; }
		[ForeignKey("Unvan")]
		public int Unvan_Id { get; set; }
		public Unvan? Unvan { get; set; }
		public List<Basvuru>? Basvurus { get; set; }
		public List<Personel_Role>? Personel_Roles { get; set; }
		public List<Makale>? Makales { get; set; }
		public List<Odul>? Oduls { get; set; }
		public List<BilimselToplanti>? BilimselToplantis { get; set; }
		public List<Gorev>? Gorevs { get; set; }
		public List<Kitap>? Kitaps { get; set; }
		public List<Konservatuvar>? Konservatuvars { get; set; }
		public List<EoFaaliyetleri>? EoFaaliyetleris { get; set; }
		public List<Atif>? Atifs { get; set; }
		public List<ArastirmaProjesi>? ArastirmaProjesis { get; set; }
		public List<TezYoneticiligi>? TezYoneticiligis { get; set; }
		public List<Patent>? Patents { get; set; }
		public List<Editorluk>? Editorluks { get; set; }
		public List<DegerlendirmeBelge>? DegerlendirmeBelges { get; set; }
	}
}
