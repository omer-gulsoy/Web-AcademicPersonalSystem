using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class ForgetPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
