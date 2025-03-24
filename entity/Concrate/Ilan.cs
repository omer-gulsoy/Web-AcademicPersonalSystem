using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Ilan
	{
		[Key]
		public int Ilan_Id { get; set; }
		public string? Baslik { get; set; }
		public string? Aciklama { get; set; }
		public DateTime? Tarih { get; set; }
		public bool Status { get; set; }
		public List<Basvuru>? Basvurus { get; set; }
	}
}
