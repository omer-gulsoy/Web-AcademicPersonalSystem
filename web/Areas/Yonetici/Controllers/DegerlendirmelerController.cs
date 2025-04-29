using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	public class DegerlendirmelerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
