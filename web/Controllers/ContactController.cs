using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class ContactController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			Context.Contacts.Add(contact);
			Context.SaveChanges();
			ViewBag.Message = "Mesajınız başarılı şekilde iletilmiştir.";
			return View();
		}
	}
}
