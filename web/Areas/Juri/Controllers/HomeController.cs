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
			ViewBag.Degerlendirmeler = Context.DegerlendirmeBelges.OrderBy(x => x.Basvuru_Id).ToList();
			ViewBag.Basvurular = Context.Basvurus
				.Include(b => b.Ilan).OrderBy(x => x.Ilan.Baslik).ToList();
			ViewBag.Personeller = Context.Personels.ToList();
			return View();
		}
	}
}