using data.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Aday.Controllers
{
	[Area("Aday")]
	public class Basvurularim : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{
			var userTc = User.Identity.Name; // veya User.FindFirst(ClaimTypes.Name)?.Value;

			// userTc ile Personel bul
			var personelId = Context.Personels
							.Where(p => p.TC == userTc)
							.Select(p => p.Personel_Id)
							.FirstOrDefault();

			var degerler = Context.Basvurus.Where(x => x.Personel_Id == personelId).Include(x => x.Ilan).Include(x=>x.BasvuruStatu).OrderBy(x => x.Ilan.Baslik).ToList();
			return View(degerler);
		}
	}
}
