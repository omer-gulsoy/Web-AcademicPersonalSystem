using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class IlanController : Controller
	{
		Context Context = new Context();

		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Ilans.ToList();
			return View(degerler);
		}

		[HttpPost]
		public IActionResult IlanAdd(Ilan e)
		{
			if (e != null)
			{
				Context.Ilans.Add(e);
				Context.SaveChanges();
				return RedirectToAction("Index", "Ilan");
			}
			return BadRequest("Ilan eklenirken hata oluştu!");
		}

		[HttpPost]
		public IActionResult IlanDelete(int id)
		{
			var silinecek = Context.Ilans.Find(id);
			if (silinecek != null)
			{
				Context.Ilans.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult IlanGet(int id)
		{
			var getirilecek = Context.Ilans.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(new
			{
				Ilan_Id = getirilecek.Ilan_Id,
				Baslik = getirilecek.Baslik,
				Aciklama = getirilecek.Aciklama,
				Tarih = getirilecek.Tarih,
				Status = getirilecek.Status,
			});
		}

		[HttpPost]
		public IActionResult IlanUpdate([FromBody] Ilan c)
		{
			var guncellenecek = Context.Ilans.Find(c.Ilan_Id);
			if (guncellenecek != null)
			{
				guncellenecek.Baslik = c.Baslik;
				guncellenecek.Aciklama = c.Aciklama;
				guncellenecek.Tarih = c.Tarih;
				guncellenecek.Status = c.Status;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
	}
}
