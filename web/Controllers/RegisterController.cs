using dto.dtos.AppUserDtos;
using entity.Concrate;
using KPSPublic;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Globalization;
using KPSPublic;
using data.Concrate;
using Microsoft.AspNetCore.Mvc.Rendering;
using MailKit.Security; // Connected Service namespace

namespace web.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly data.Concrate.Context _context;
		public RegisterController(UserManager<AppUser> userManager, data.Concrate.Context context)
		{
			_userManager = userManager;
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{

			var unvanlar = _context.Unvans.ToList();
			ViewBag.UnvanList = new SelectList(unvanlar, "Unvan_Id", "Isim");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			if (ModelState.IsValid)
			{
				// 🔐 TC Kimlik Doğrulama
				try
				{
					var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
					var result = await client.TCKimlikNoDogrulaAsync(
						Convert.ToInt64(appUserRegisterDto.UserName),
						appUserRegisterDto.Name.ToUpper(new CultureInfo("tr-TR")),
						appUserRegisterDto.Surname.ToUpper(new CultureInfo("tr-TR")),
						appUserRegisterDto.BirthYear
					);

					if (!result.Body.TCKimlikNoDogrulaResult)
					{
						ModelState.AddModelError("", "T.C. Kimlik, Ad, Soyad, Doğum yılı bilgileri uyuşmuyor.");
						return View();
					}
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", "Kimlik doğrulama servisine ulaşılamadı: " + ex.Message);
					return View();
				}

				AppUser appUser = new AppUser
				{
					UserName = appUserRegisterDto.UserName,
					Email = appUserRegisterDto.Email,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.Surname,
					BirthYear = appUserRegisterDto.BirthYear,
				};

				var resultUser = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
				if (resultUser.Succeeded)
				{
					await _userManager.AddToRoleAsync(appUser, "ADAY");

					// ➕ BURAYA EKLE
					Personel personel = new Personel
					{
						Isim = appUserRegisterDto.Name,
						Soyisim = appUserRegisterDto.Surname,
						TC = appUserRegisterDto.UserName,
						Eposta = appUserRegisterDto.Email,
						Status = true,
						Telefon = appUserRegisterDto.PhoneNumber, // varsa
						Unvan_Id = appUserRegisterDto.Unvan_Id, // örnek
					};

					_context.Personels.Add(personel);
					await _context.SaveChangesAsync();
					//kullanıcıya gönderilen e-posta
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Akademik Personel Sistemi", "o.hasan.41.41@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("Yeni Kullanıcı", appUserRegisterDto.Email);
					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);
					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Akademik Personel Sistemine kayıt başvurunuz başarıyla gerçekleşmiştir. Sistem yöenticimiz tarafından başvurunuz incelenecektir. Başvurunuzun onaylanması halinde sisteme giriş sağlayabileceksiniz.\nZeka Atölyesi Eğitim Kurumu\nTeşekkürler.";
					mimeMessage.Body = bodyBuilder.ToMessageBody();
					mimeMessage.Subject = "Akademik Personel Sistemine kayıt başvurusu.";

					//yöneticiye gönderilen e-posta
					MimeMessage mimeMessage2 = new MimeMessage();
					MailboxAddress mailboxAddressFrom2 = new MailboxAddress("Akademik Personel Sistemi", "o.hasan.41.41@gmail.com");
					MailboxAddress mailboxAddressTo2 = new MailboxAddress("Yönetici", "omerhasangulsoy@hotmail.com");
					mimeMessage2.From.Add(mailboxAddressFrom2);
					mimeMessage2.To.Add(mailboxAddressTo2);
					var bodyBuilder2 = new BodyBuilder();
					bodyBuilder2.TextBody = "Dershane sistemine yeni bir kayıt eklendi. Kişiyi görüntülemek, yetki vermek, onaylamak için bağlantıya gidin. https://localhost:44356/Login/Index";
					mimeMessage2.Body = bodyBuilder2.ToMessageBody();
					mimeMessage2.Subject = "Dershane sistemine yeni kayıt eklendi.";

					//gönderim işlemi sağlayıcısı
					SmtpClient clientMail = new SmtpClient();
					clientMail.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
					clientMail.Authenticate("o.hasan.41.41@gmail.com", "mnkvwyooiduvxbdt");
					clientMail.Send(mimeMessage);
					clientMail.Send(mimeMessage2);
					clientMail.Disconnect(true);

					return RedirectToAction("Index", "Login");
				}
				else
				{
					foreach (var item in resultUser.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}