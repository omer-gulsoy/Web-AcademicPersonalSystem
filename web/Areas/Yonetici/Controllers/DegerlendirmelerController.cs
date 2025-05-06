using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	//[Authorize(Roles = "YONETICI")]
	public class DegerlendirmelerController : Controller
	{
		Context Context = new Context();
		public IActionResult Index()
		{
			var degerler = Context.DegerlendirmeBelges
				.Include(x => x.Basvuru)
					.ThenInclude(x => x.Ilan)
				.Include(x => x.Personel)
					.ThenInclude(x => x.Unvan)
				.Where(x => x.Personel != null)
				.ToList();
			return View(degerler);
		}
	}
}
