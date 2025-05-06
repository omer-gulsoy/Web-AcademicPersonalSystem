using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class BasvurularController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Ilanlar = Context.Ilans.OrderBy(x => x.Baslik).Take(6).ToList();
			ViewBag.Basvurular = Context.Basvurus.OrderBy(x => x.Ilan.Baslik).ToList();
			ViewBag.Unvanlar = Context.Unvans.ToList();
			ViewBag.Personeller = Context.Personels.ToList();
			ViewBag.BasvuruStatuleri = Context.BasvuruStatus.ToList();
			return View();
		}
		[HttpGet]
		public IActionResult Yonlendir(int id)
		{
			// JURI rolüne sahip personel verisini al
			var juriRoles = (from user in Context.Users
							 join userRole in Context.UserRoles on user.Id equals userRole.UserId
							 join role in Context.Roles on userRole.RoleId equals role.Id
							 join personel in Context.Personels on user.UserName equals personel.TC
							 where role.Name == "JURI"
							 select new
							 {
								 PersonelId = personel.Personel_Id,
								 Isim = personel.Isim,
								 Soyisim = personel.Soyisim
							 }).ToList();

			// Dropdown için veri modeli oluştur
			ViewBag.JuriPersoneller = juriRoles;

			var model = new BasvuruYonlendir
			{
				Basvuru_Id = id
			};
			return View(model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Yonlendir(BasvuruYonlendir yonlendir)
		{
			if (ModelState.IsValid)
			{
				Context.BasvuruYonlendirs.Add(yonlendir);
				Context.SaveChanges();
				TempData["Success"] = "Başvuru başarılı şekilde yönlendirildi.";
				return RedirectToAction("Index");
			}
			return View(yonlendir);
		}

	}
}
