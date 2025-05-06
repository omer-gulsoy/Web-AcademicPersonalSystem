using data.Concrate;
using dto.viewmodels;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Juri.Controllers
{
	[Area("Juri")]
	[Authorize(Roles = "JURI")]
	public class Degerlendir : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var userTc = User.Identity.Name;
			var personelId = Context.Personels
				.Where(p => p.TC == userTc)
				.Select(p => p.Personel_Id)
				.FirstOrDefault();

			var model = Context.BasvuruYonlendirs
				.Include(x => x.Basvuru)
					.ThenInclude(b => b.Personel)
				.Include(x => x.Basvuru)
					.ThenInclude(b => b.Ilan)
				.Where(x => x.Personel_Id == personelId)
				.Select(x => new BasvuruJuriViewModel
				{
					BasvuruId = x.Basvuru_Id.Value,
					Isim = x.Basvuru.Personel.Isim,
					Soyisim = x.Basvuru.Personel.Soyisim,
					Eposta = x.Basvuru.Personel.Eposta,
					Telefon = x.Basvuru.Personel.Telefon,
					IlanBaslik = x.Basvuru.Ilan.Baslik,
					DosyaYolu = Context.DegerlendirmeBelges
						.Where(d => d.Basvuru_Id == x.Basvuru_Id && d.Personel_Id == personelId)
						.Select(d => d.DosyaYolu)
						.FirstOrDefault()
				})
				.ToList();

			return View(model);
		}

		[HttpPost]
		public IActionResult Index(IFormFile resim, int Basvuru_Id)
		{
			if (resim == null || resim.Length == 0)
			{
				TempData["Error"] = "Dosya seçilmedi.";
				return RedirectToAction("Index", "Home"); // Formdan sonra dönülecek yer
			}

			// 1. TC'den personel ID'yi bul
			var userTc = User.Identity.Name;
			var personelId = Context.Personels
				.Where(p => p.TC == userTc)
				.Select(p => p.Personel_Id)
				.FirstOrDefault();

			// 2. Dosya ismi benzersiz hale getir
			var uzanti = Path.GetExtension(resim.FileName);
			var benzersizAd = Guid.NewGuid().ToString() + uzanti;
			var kayitYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dosyalar", benzersizAd);

			// 3. Dosyayı kaydet
			using (var stream = new FileStream(kayitYolu, FileMode.Create))
			{
				resim.CopyTo(stream);
			}

			// 4. Veritabanına kayıt
			var belge = new DegerlendirmeBelge
			{
				DosyaYolu = "/dosyalar/" + benzersizAd,
				Basvuru_Id = Basvuru_Id,
				Personel_Id = personelId
			};

			Context.DegerlendirmeBelges.Add(belge);
			Context.SaveChanges();

			TempData["Success"] = "Dosya başarıyla yüklendi.";
			return RedirectToAction("Index", "Home"); // Dönüş yapılacak yer
		}


	}
}