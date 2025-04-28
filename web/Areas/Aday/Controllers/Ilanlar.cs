using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Aday.Controllers
{
	[Area("Aday")]
	public class Ilanlar : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Ilans.Where(x => x.Status == true).OrderBy(x => x.Baslik).ToList();
			return View(degerler);
		}
	}
}
