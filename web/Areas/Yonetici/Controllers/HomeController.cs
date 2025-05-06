using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	//[Authorize(Roles = "YONETICI")]
	public class HomeController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{

			ViewBag.Ilanlar = Context.Ilans.OrderBy(x => x.Baslik).Take(6).ToList();
			ViewBag.Basvurular = Context.Basvurus.OrderBy(x => x.Ilan.Baslik).Take(10).ToList();
			ViewBag.Personeller = Context.Personels.ToList();
			return View();
		}
	}
}
