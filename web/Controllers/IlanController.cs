using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class IlanController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{
			var degerler = Context.Ilans.Where(x => x.Status == true).OrderByDescending(x => x.Tarih).ToList();
			return View(degerler);
		}
	}
}
