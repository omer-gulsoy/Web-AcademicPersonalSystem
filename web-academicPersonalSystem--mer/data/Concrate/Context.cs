using entity.Concrate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Concrate
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//Derya DB
			optionsBuilder.UseSqlServer("server=DERYA\\HUAWEI;database=AcademicDB;integrated security=true;TrustServerCertificate=True;");
		}
		public DbSet<ArastirmaProjesi>? ArastirmaProjesis { get; set; }
		public DbSet<Atif>? Atifs { get; set; }
		public DbSet<Basvuru>? Basvurus { get; set; }
		public DbSet<BasvuruStatu>? BasvuruStatus { get; set; }
		public DbSet<BasvuruYonlendir>? BasvuruYonlendirs { get; set; }
		public DbSet<Belge>? Belges { get; set; }
		public DbSet<BilimselToplanti>? BilimselToplantis { get; set; }
		public DbSet<Contact>? Contacts { get; set; }
		public DbSet<DegerlendirmeBelge>? DegerlendirmeBelges { get; set; }
		public DbSet<Editorluk>? Editorluks { get; set; }
		public DbSet<EoFaaliyetleri>? EoFaaliyetleris { get; set; }
		public DbSet<Gorev>? Gorevs { get; set; }
		public DbSet<Ilan>? Ilans { get; set; }
		public DbSet<Katsayi>? Katsayis { get; set; }
		public DbSet<Kitap>? Kitaps { get; set; }
		public DbSet<Konservatuvar>? Konservatuvars { get; set; }
		public DbSet<Makale>? Makales { get; set; }
		public DbSet<Odul>? Oduls { get; set; }
		public DbSet<Patent>? Patents { get; set; }
		public DbSet<Personel>? Personels { get; set; }
		public DbSet<Personel_Role>? Personel_Roles { get; set; }
		public DbSet<Puanlama>? Puanlamas { get; set; }
		public DbSet<Rol>? Rols { get; set; }
		public DbSet<TezYoneticiligi>? TezYoneticiligis { get; set; }
		public DbSet<Unvan>? Unvans { get; set; }
	}
}
