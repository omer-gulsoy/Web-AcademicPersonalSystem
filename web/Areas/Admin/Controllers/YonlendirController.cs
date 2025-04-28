using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class YonlendirController : Controller
	{

		Context Context = new Context();

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Ilanlar=Context.Ilans.ToList();
			var basvurular = Context.Basvurus
									.Include(b => b.Personel)  // Personel ilişkisini dahil et
									.ThenInclude(p=>p.Unvan)
									.Include(b => b.Ilan)      // İlan ilişkisini dahil et (varsa)
									.Include(b => b.BasvuruStatu) // Başvuru durumunu dahil et (varsa)
									.ToList();

			ViewBag.Basvurular = basvurular;
			var degerler = Context.BasvuruYonlendirs.ToList();
			return View(degerler);
		}

		[HttpPost]
		public IActionResult YonlendirAdd(BasvuruYonlendir e)
		{
			if (e != null)
			{
				Context.BasvuruYonlendirs.Add(e);
				Context.SaveChanges();
				return RedirectToAction("Index", "Yonlendir");
			}
			return BadRequest("Yönlendirilirken hata oluştu!");
		}

		[HttpPost]
		public IActionResult YonlendirDelete(int id)
		{
			var silinecek = Context.BasvuruYonlendirs.Find(id);
			if (silinecek != null)
			{
				Context.BasvuruYonlendirs.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult YonlendirGet(int id)
		{
			var getirilecek = Context.BasvuruYonlendirs.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(new
			{
				BasvuruYonlendir_Id = getirilecek.BasvuruYonlendir_Id,
				Basvuru_Id = getirilecek.Basvuru_Id,
				Personel_Id = getirilecek.Personel_Id,
			});
		}

		[HttpPost]
		public IActionResult YonlendirUpdate([FromBody] BasvuruYonlendir c)
		{
			var guncellenecek = Context.BasvuruYonlendirs.Find(c.BasvuruYonlendir_Id);
			if (guncellenecek != null)
			{
				guncellenecek.BasvuruYonlendir_Id = c.BasvuruYonlendir_Id;
				guncellenecek.Basvuru_Id = c.Basvuru_Id;
				guncellenecek.Personel_Id = c.Personel_Id;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
	}
}
