using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web.Areas.Yonetici.Controllers
{
	[Area("Yonetici")]
	//[Authorize(Roles = "YONETICI")]
	public class JurilerController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly Context _context;

		public JurilerController(
			UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			Context context)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var juriUsers = await _userManager.GetUsersInRoleAsync("JURI");
			var juriTCs = juriUsers.Select(u => u.UserName).ToList();

			var juriler = _context.Personels
				.ToList()
				.Where(p => juriTCs.Contains(p.TC))
				.OrderBy(p => p.Isim)
				.ToList();

			// Juri olmayanlar
			var juriOlmayanlar = _context.Personels
				.ToList()
				.Where(p => !juriTCs.Contains(p.TC))
				.OrderBy(p => p.Isim)
				.ToList();

			ViewBag.PersonelList = juriOlmayanlar;

			return View(juriler);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> JuriYap([FromBody] int personelId)
		{
			var personel = await _context.Personels.FirstOrDefaultAsync(p => p.Personel_Id == personelId);
			if (personel == null)
				return NotFound();

			var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == personel.TC);
			if (user == null)
				return NotFound();

			var currentRoles = await _userManager.GetRolesAsync(user);
			await _userManager.RemoveFromRolesAsync(user, currentRoles);

			await _userManager.AddToRoleAsync(user, "JURI");

			return Ok();
		}


	}
}
