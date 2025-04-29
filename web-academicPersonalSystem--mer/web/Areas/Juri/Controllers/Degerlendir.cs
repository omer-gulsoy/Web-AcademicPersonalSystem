using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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


			var userTc = User.Identity.Name; // veya User.FindFirst(ClaimTypes.Name)?.Value;

			// userTc ile Personel bul
			var personelId = Context.Personels
							.Where(p => p.TC == userTc)
							.Select(p => p.Personel_Id)
							.FirstOrDefault();


			var degerler = Context.Basvurus	
				.Include(b => b.Ilan)         // İlan'ı dahil et
				.Include(b => b.BasvuruStatu) // BaşvuruStatüyü dahil et
				.Include(b => b.Personel)     // Başvuruyu yapan Personel'i dahil et
					.ThenInclude(p => p.Unvan) // Personelin Unvanını dahil et
				.Where(b => Context.BasvuruYonlendirs
					.Any(by => by.Basvuru_Id == b.Basvuru_Id && by.Personel_Id == personelId))
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
