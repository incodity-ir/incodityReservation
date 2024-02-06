using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using incodityReservation.Infrastructure.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Infrastructure.Persistence
{
    public class SqlServerApplicationDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=incodityRSVdb;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Province>().ToTable("OstanHa");
            modelBuilder.Entity<Villa>().Property(p => p.Name).HasMaxLength(10);
            //base.OnModelCreating(modelBuilder);
            */

            /*
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new ProvinceConfig());
            modelBuilder.ApplyConfiguration(new VillaConfig());
            */

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CityConfig).Assembly);
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Citys { get; set; }
    }
}
