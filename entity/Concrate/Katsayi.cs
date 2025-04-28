using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Katsayi
	{
		[Key]
		public int Katsayi_Id { get; set; }
		public int CalisanSayi { get; set; }
		public double Katsayisi { get; set; }
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
	}
}
