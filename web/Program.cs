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
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminPolicy", policy =>
		policy.RequireRole("ADMIN"));

	options.AddPolicy("YoneticiPolicy", policy =>
		policy.RequireRole("YONETICI"));

	options.AddPolicy("AdayPolicy", policy =>
		policy.RequireRole("ADAY"));

	options.AddPolicy("JuriPolicy", policy =>
		policy.RequireRole("JURI"));
});


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
