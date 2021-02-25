using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Data> Data { get; set; }
		public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
    }
	//For migrations
	public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
	{
		public EFDBContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDataBase;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

			return new EFDBContext(optionsBuilder.Options);
		}
	}
}
