using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace web.Controllers
{
	public class HomeIndexViewModel
	{
		public List<Ilan> Ilanlar { get; set; }
		public Contact Contact { get; set; }
	}
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var model = new HomeIndexViewModel
			{
				Ilanlar = Context.Ilans.Where(x => x.Status == true).OrderBy(x => x.Tarih).ToList(),
				Contact = new Contact()
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			if (ModelState.IsValid)
			{
				Context.Contacts.Add(contact);
				Context.SaveChanges();

				// POST-REDIRECT-GET pattern'ı uyguluyoruz
				TempData["Message"] = "Mesajınız başarılı şekilde iletilmiştir.";
				return RedirectToAction("Index");
			}

			// Validasyon hatası varsa modeli tekrar oluştur
			var model = new HomeIndexViewModel
			{
				Ilanlar = Context.Ilans.Where(x => x.Status == true).OrderBy(x => x.Tarih).ToList(),
				Contact = contact // Kullanıcının girdiği verileri koru
			};

			return View(model);
		}
	}
}
