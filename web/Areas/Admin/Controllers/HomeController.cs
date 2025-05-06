using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Ilanlar = Context.Ilans.OrderBy(x => x.Baslik).Take(6).ToList();
			ViewBag.Basvurular = Context.Basvurus.OrderBy(x => x.Ilan.Baslik).Take(10).ToList();
			ViewBag.Personeller = Context.Personels.ToList();
			return View();
		}
	}
}
