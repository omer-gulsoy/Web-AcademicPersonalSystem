using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Ilans.Where(x=>x.Status==true).OrderBy(x => x.Tarih).ToList();
			return View(degerler);
		}
	}
}
