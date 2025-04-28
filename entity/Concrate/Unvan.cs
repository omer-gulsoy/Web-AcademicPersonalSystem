using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Unvan
	{
		[Key]
		public int Unvan_Id { get; set; }
		public string? Isim { get; set; }
		public List<Personel>? Personels { get; set; }
	}
}
