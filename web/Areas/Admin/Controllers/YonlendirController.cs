using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	public class YonlendirController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
