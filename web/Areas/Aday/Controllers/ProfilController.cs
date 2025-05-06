using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Aday.Controllers
{
	[Area("Aday")]
	[Authorize(Roles = "ADAY")]
	public class ProfilController : Controller
	{
		Context Context = new Context();

		// GET metodu
		public IActionResult Index()
		{
			var userTc = User.Identity.Name; // veya User.FindFirst(ClaimTypes.Name)?.Value;

			// userTc ile Personel bul
			var personelId = Context.Personels
							.Where(p => p.TC == userTc)
							.Select(p => p.Personel_Id)
							.FirstOrDefault();
			ViewBag.PersonelId = personelId;
			return View();
		}

		// POST metodu
		[HttpPost]
		public IActionResult Index(Personel personel)
		{
			if (ModelState.IsValid)
			{
				Context.Personels.Add(personel);  // Veritabanına ekleme işlemi
				Context.SaveChanges();  // Değişiklikleri kaydet
				return RedirectToAction("Index");  // Kaydetme işleminden sonra kullanıcıyı profil sayfasına yönlendir
			}
			return View(personel);  // Eğer model hatalıysa tekrar formu göster
		}
		[HttpGet]
		public IActionResult Arastirma()
		{
			ViewBag.Goster=Context.Katsayis.ToList();
			return View();
		}
		[HttpGet]
		public IActionResult Atif()
		{
			return View();
		}
		[HttpGet]
		public IActionResult BilimselToplanti()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Editorluk()
		{
			return View();
		}
		[HttpGet]
		public IActionResult EoFaaliyeti()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Gorev()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Kitap()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Konservatuar()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Makale()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Odul()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Patent()
		{
			return View();
		}
		[HttpGet]
		public IActionResult TezYoneticiligi()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Arastirma(ArastirmaProjesi A, int id)
		{
			A.Personel_Id = id;
			Context.ArastirmaProjesis.Add(A);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}


		[HttpPost]
		public IActionResult Atif(Atif A, int id)
		{
			A.Personel_Id = id;
			Context.Atifs.Add(A);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult BilimselToplanti(BilimselToplanti B, int id)
		{
			B.Personel_Id = id;
			Context.BilimselToplantis.Add(B);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Editorluk(Editorluk E, int id)
		{
			E.Personel_Id = id;
			Context.Editorluks.Add(E);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult EoFaaliyeti(EoFaaliyetleri E, int id)
		{
			E.Personel_Id = id;
			Context.EoFaaliyetleris.Add(E);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Gorev(Gorev G, int id)
		{
			G.Personel_Id = id;
			Context.Gorevs.Add(G);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Kitap(Kitap K, int id)
		{
			K.Personel_Id = id;
			Context.Kitaps.Add(K);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Konservatuar(Konservatuvar K, int id)
		{
			K.Personel_Id = id;
			Context.Konservatuvars.Add(K);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Makale(Makale M, int id)
		{
			M.Personel_Id = id;
			Context.Makales.Add(M);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Odul(Odul O, int id)
		{
			O.Personel_Id = id;
			Context.Oduls.Add(O);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult Patent(Patent P, int id)
		{
			P.Personel_Id = id;
			Context.Patents.Add(P);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
		[HttpPost]
		public IActionResult TezYoneticiligi(TezYoneticiligi T, int id)
		{
			T.Personel_Id = id;
			Context.TezYoneticiligis.Add(T);
			Context.SaveChanges();
			return RedirectToAction("Index", "Profil");
		}
	}
}
