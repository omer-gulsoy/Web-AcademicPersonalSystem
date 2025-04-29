using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	public class IlanlarController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Ilanlar = Context.Ilans.OrderBy(x=>x.Baslik).ToList();
			return View();
		}
	}
}
