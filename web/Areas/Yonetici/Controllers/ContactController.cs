using data.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	//[Authorize(Roles = "YONETICI")]
	public class ContactController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Contacts.ToList();
			return View(degerler);
		}
		[HttpPost]
		public IActionResult ContactDelete([FromBody] int id)
		{
			var silinecek = Context.Contacts.Find(id);
			if (silinecek != null)
			{
				Context.Contacts.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
	}
}
