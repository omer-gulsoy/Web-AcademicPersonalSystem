using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BasvuruController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Basvurus
			.Include(b => b.Ilan)
			.Include(b => b.BasvuruStatu)
			.Include(b => b.Personel)
			.ThenInclude(b => b.Unvan)
			.OrderBy(b => b.Ilan_Id)
			.ToList();
			return View(degerler);
		}
		[HttpPost]
		public IActionResult BasvuruDelete(int id)
		{
			var silinecek = Context.Basvurus.Find(id);
			if (silinecek != null)
			{
				Context.Basvurus.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
		[HttpGet]
		public IActionResult BasvuruGet(int id)
		{
			var getirilecek = Context.Basvurus
				.Include(b => b.Personel)
				.FirstOrDefault(b => b.Basvuru_Id == id);

			if (getirilecek == null || getirilecek.Personel == null)
			{
				return NotFound();
			}

			return Json(new
			{
				Basvuru_Id = getirilecek.Basvuru_Id,
				BasvuruStatu_Id = getirilecek.BasvuruStatu_Id,
				Ilan_Id = getirilecek.Ilan_Id,
				Personel_Id = getirilecek.Personel_Id,
				Personel_TC = getirilecek.Personel.TC,
				Personel_Eposta = getirilecek.Personel.Eposta,
				Personel_Telefon = getirilecek.Personel.Telefon
			});
		}

		[HttpPost]
		public IActionResult BasvuruUpdate([FromBody] Basvuru c)
		{
			var guncellenecek = Context.Basvurus.Find(c.Basvuru_Id);
			if (guncellenecek != null)
			{
				guncellenecek.BasvuruStatu_Id = c.BasvuruStatu_Id;
				guncellenecek.Ilan_Id = c.Ilan_Id;
				guncellenecek.Personel_Id = c.Personel_Id;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult IlanDetay(int id)
		{
			var ilan = Context.Ilans.FirstOrDefault(i => i.Ilan_Id == id);
			if (ilan == null)
			{
				return NotFound();
			}
			return Json(new
			{
				Baslik = ilan.Baslik,
				Aciklama = ilan.Aciklama,
				Tarih = ilan.Tarih
			});
		}

	}
}
