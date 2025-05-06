using entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using web.Models;

namespace web.Controllers
{
    public class ForgetPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ForgetPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı.");
                    return View();
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = Url.Action("ResetPassword", "ForgetPassword", new { token, email = model.Email }, Request.Scheme);

                try
                {
                    var mimeMessage = new MimeMessage();
                    mimeMessage.From.Add(new MailboxAddress("Akademik Başvuru Sistemi", "seninmailadresin@gmail.com"));
                    mimeMessage.To.Add(new MailboxAddress(user.Name, model.Email));
                    mimeMessage.Subject = "Şifre Sıfırlama Talebi";

                    var bodyBuilder = new BodyBuilder
                    {
                        HtmlBody = $"<p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayınız:</p><p><a href='{resetLink}'>Şifreyi Sıfırla</a></p>"
                    };

                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                        client.Authenticate("o.hasan.41.41@gmail.com", "mnkvwyooiduvxbdt");
                        client.Send(mimeMessage);
                        client.Disconnect(true);
                    }

                    TempData["MailSuccess"] = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.";
                    return RedirectToAction("Index", "Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "E-posta gönderimi sırasında bir hata oluştu: " + ex.Message);
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                    return View(model);
                }

                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifreler eşleşmiyor.");
                    return View(model);
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    TempData["ResetSuccess"] = "Şifreniz başarıyla sıfırlandı.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
