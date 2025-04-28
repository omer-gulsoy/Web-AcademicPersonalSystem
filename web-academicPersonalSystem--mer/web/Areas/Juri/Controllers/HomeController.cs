using data.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Juri.Controllers
{
	[Area("Juri")]
	public class HomeController : Controller
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

			ViewBag.Basvurular = Context.BasvuruYonlendirs.Where(x => x.Personel_Id == personelId).Include(x => x.Basvuru).ThenInclude(x => x.Ilan).OrderBy(x => x.Basvuru.Ilan.Baslik).ToList();
			//ViewBag.Basvurular = Context.Basvurus.Where(x=).Include(b => b.Ilan).OrderBy(x => x.Ilan.Baslik).ToList();


			ViewBag.Degerlendirmeler = Context.DegerlendirmeBelges.OrderBy(x => x.Basvuru_Id).ToList();
			ViewBag.Personeller = Context.Personels.ToList();
			return View();
		}
	}
}