using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Contact
	{
		[Key]
		public int Contact_Id { get; set; }
		public string? Isim { get; set; }
		public string? Soyisim { get; set; }
		public string? Eposta { get; set; }
		public string? Konu { get; set; }
		public string? Mesaj { get; set; }
	}
}
