using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Aday.Controllers
{
	[Area("Aday")]
	public class Ilanlar : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
