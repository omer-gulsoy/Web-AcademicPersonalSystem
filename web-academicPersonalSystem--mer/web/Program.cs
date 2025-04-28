using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);



// --- buraya ekle ---
builder.Services.Configure<FormOptions>(options =>
{
	options.MultipartBodyLengthLimit = 100_000_000; // 100 MB limiti (istersen büyütebilirsin)
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddErrorDescriber<CustomIdentityErrorDescriber>() // Türkçe hata mesajý için burasý önemli
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();


// Statik dosyalar izinli olsun
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name: "Admin",
		areaName: "Admin",
		pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapAreaControllerRoute(
		name: "Aday",
		areaName: "Aday",
		pattern: "Aday/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapAreaControllerRoute(
		name: "Juri",
		areaName: "Juri",
		pattern: "Juri/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapAreaControllerRoute(
		name: "Yonetici",
		areaName: "Yonetici",
		pattern: "Yonetici/{controller=Home}/{action=Index}/{id?}"
		);
	endpoints.MapDefaultControllerRoute();
});


app.Run();
