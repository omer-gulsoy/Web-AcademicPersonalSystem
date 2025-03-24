using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Basvuru
	{
		[Key]
		public int Basvuru_Id { get; set; }
		public int Statu { get; set; }
		public List<Belge>? Belges { get; set; }
	}
}
