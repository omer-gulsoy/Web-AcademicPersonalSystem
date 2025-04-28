using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class BasvuruStatu
	{
		[Key]
		public int BasvuruStatu_Id { get; set; }
		public string? Statu { get; set; }
		public Basvuru? Basvurus { get; set; }
	}
}
