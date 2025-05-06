using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Aday.Controllers
{
	[Area("Aday")]
	[Authorize(Roles = "ADAY")]
	public class Ilanlar : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Ilans.Where(x => x.Status == true).OrderBy(x => x.Baslik).ToList();
			return View(degerler);
		}
		[HttpPost]
		public IActionResult BasvuruYap(int ilanId)
		{
			// Kullanıcının TC'si üzerinden Personel_Id'yi buluyoruz
			var userTc = User.Identity.Name;
			var personelId = Context.Personels
									.Where(p => p.TC == userTc)
									.Select(p => p.Personel_Id)
									.FirstOrDefault();

			// Başvuru nesnesi oluşturuyoruz
			var basvuru = new Basvuru
			{
				Ilan_Id = ilanId,
				Personel_Id = personelId,
				BasvuruStatu_Id = 1 // Başvuru durumu başlangıçta 1 olacak
			};

			// Veritabanına ekliyoruz
			Context.Basvurus.Add(basvuru);
			Context.SaveChanges();

			return RedirectToAction("Index"); // Başvurular sayfasına geri yönlendirebiliriz.
		}

	}
}
