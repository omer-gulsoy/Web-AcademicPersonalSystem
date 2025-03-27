using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Ilanlar = Context.Ilans.ToList();
			ViewBag.Basvurular = Context.Basvurus.ToList();
			ViewBag.Personeller = Context.Personels.ToList();
			return View();
		}
	}
}
