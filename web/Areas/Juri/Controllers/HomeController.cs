using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Juri.Controllers
{
	[Area("Juri")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}