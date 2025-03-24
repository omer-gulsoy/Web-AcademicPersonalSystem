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
			//ömer DB
			optionsBuilder.UseSqlServer("server=ELITEBOOK\\MSSQLSERVER2012;database=DershaneDB;integrated security=true;TrustServerCertificate=True;");
		}
	}
}
