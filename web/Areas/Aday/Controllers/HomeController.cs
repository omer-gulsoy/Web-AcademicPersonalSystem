using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Aday.Controllers
{
	[Area("Aday")]
	[Authorize(Roles = "ADAY")]
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var userTc = User.Identity.Name; // veya User.FindFirst(ClaimTypes.Name)?.Value;

			// userTc ile Personel bul
			var personelId = Context.Personels
							.Where(p => p.TC == userTc)
							.Select(p => p.Personel_Id)
							.FirstOrDefault();

			ViewBag.Basvurular = Context.Basvurus.Where(x => x.Personel_Id == personelId).Include(x => x.Ilan).ToList();
			ViewBag.Ilanlar = Context.Ilans.Where(x => x.Status == true).Take(10).ToList();
			return View();
		}
	}
}
