using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Juri.Controllers
{
	[Area("Juri")]
	public class Degerlendir : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Basvurus
			.Include(b => b.Ilan)       // İlan'ı dahil et
			.Include(b => b.BasvuruStatu)
			.Include(b => b.Personel)   // Personel'i dahil et)
			.ThenInclude(p => p.Unvan) // Personel'den Unvan'ı dahil et
			.OrderBy(x => x.Ilan_Id)
			.ToList();
			return View(degerler);
		}

		[HttpPost]
		public async Task<IActionResult> DosyaYukleAjax(IFormFile dosya, int basvuruId)
		{
			if (dosya != null && dosya.Length > 0)
			{
				// Dosyanın uzantısını al
				var dosyaUzantisi = Path.GetExtension(dosya.FileName);

				// Benzersiz bir dosya adı oluştur (Guid kullanarak)
				var yeniDosyaAdi = Guid.NewGuid().ToString() + dosyaUzantisi;

				// Dosyanın kaydedileceği yolu belirle
				var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "belgeler", "degerlendirme_belgeleri", yeniDosyaAdi);

				// Dosyayı kaydet
				using (var stream = new FileStream(dosyaYolu, FileMode.Create))
				{
					await dosya.CopyToAsync(stream);
				}

				// Veritabanına dosya yolunu ve diğer bilgileri ekle
				var degerlendirmeBelge = new DegerlendirmeBelge
				{
					DosyaYolu = "/belgeler/degerlendirme_belgeleri/" + yeniDosyaAdi,
					Basvuru_Id = basvuruId,
					Personel_Id = 4
				};

				// Veritabanına ekleme işlemi
				Context.DegerlendirmeBelges.Add(degerlendirmeBelge);
				await Context.SaveChangesAsync();

				// Başarılı olduğunda JSON döndür
				return Json(new { success = true, dosyaYolu = degerlendirmeBelge.DosyaYolu });
			}

			return Json(new { success = false, message = "Dosya yüklenemedi." });
		}


	}
}
