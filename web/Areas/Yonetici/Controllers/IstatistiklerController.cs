using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	//[Authorize(Roles = "YONETICI")]
	public class IstatistiklerController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{
			var degerler = Context.Ilans.Include(x => x.Basvurus).OrderBy(x => x.Baslik).ToList();
			return View(degerler);
		}
	}
}
