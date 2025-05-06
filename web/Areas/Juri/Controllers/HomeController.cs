using data.Concrate;
using dto.viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Juri.Controllers
{
	[Area("Juri")]
	[Authorize(Roles = "JURI")]
	public class HomeController : Controller
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
	}
}