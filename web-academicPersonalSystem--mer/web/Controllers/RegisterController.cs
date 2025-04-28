using dto.dtos.AppUserDtos;
using entity.Concrate;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                // Confirm Password kontrolü
                if (appUserRegisterDto.Password != appUserRegisterDto.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifre ve Şifre Tekrarı aynı olmalıdır.");
                    return View();
                }

                // Kullanıcı adı var mı kontrolü
                var existingUser = await _userManager.FindByNameAsync(appUserRegisterDto.UserName);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı zaten mevcut.");
                    return View();
                }

                // E-mail var mı kontrolü
                var existingEmail = await _userManager.FindByEmailAsync(appUserRegisterDto.Email);
                if (existingEmail != null)
                {
                    ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor.");
                    return View();
                }

                AppUser appUser = new AppUser
                {
                    UserName = appUserRegisterDto.UserName,
                    Email = appUserRegisterDto.Email,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        // Kullanıcıya gönderilecek e-posta
                        MimeMessage mimeMessage = new MimeMessage();
                        MailboxAddress mailboxAddressFrom = new MailboxAddress("Dershane", "o.hasan.41.41@gmail.com");
                        MailboxAddress mailboxAddressTo = new MailboxAddress("Yeni Kullanıcı", appUser.Email);
                        mimeMessage.From.Add(mailboxAddressFrom);
                        mimeMessage.To.Add(mailboxAddressTo);
                        var bodyBuilder = new BodyBuilder
                        {
                            TextBody = "Dershane sistemine kayıt başvurunuz başarıyla gerçekleşmiştir. Sistem yöneticimiz tarafından başvurunuz incelenecektir. Başvurunuzun onaylanması halinde sisteme giriş sağlayabileceksiniz.\nZeka Atölyesi Eğitim Kurumu\nTeşekkürler."
                        };
                        mimeMessage.Body = bodyBuilder.ToMessageBody();
                        mimeMessage.Subject = "Dershane sistemine kayıt başvurusu.";

                        // Yöneticilere gönderilecek e-posta
                        MimeMessage mimeMessage2 = new MimeMessage();
                        MailboxAddress mailboxAddressFrom2 = new MailboxAddress("Dershane", "o.hasan.41.41@gmail.com");
                        MailboxAddress mailboxAddressTo2 = new MailboxAddress("Yönetici", "omerhasangulsoy@hotmail.com");
                        mimeMessage2.From.Add(mailboxAddressFrom2);
                        mimeMessage2.To.Add(mailboxAddressTo2);
                        var bodyBuilder2 = new BodyBuilder
                        {
                            TextBody = "Dershane sistemine yeni bir kayıt eklendi. Kişiyi görüntülemek, yetki vermek, onaylamak için bağlantıya gidin. https://localhost:44356/Login/Index"
                        };
                        mimeMessage2.Body = bodyBuilder2.ToMessageBody();
                        mimeMessage2.Subject = "Dershane sistemine yeni kayıt eklendi.";

                        SmtpClient client = new SmtpClient();
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("o.hasan.41.41@gmail.com", "mnkvwyooiduvxbdt");
                        client.Send(mimeMessage);
                        client.Send(mimeMessage2);
                        client.Disconnect(true);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "E-posta gönderimi sırasında bir hata oluştu: " + ex.Message);
                        return View();
                    }

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
