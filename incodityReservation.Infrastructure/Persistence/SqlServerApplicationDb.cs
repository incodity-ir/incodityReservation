using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using incodityReservation.Domain.Entities;
using incodityReservation.Domain.Entities.Security;
using incodityReservation.Infrastructure.EntitiesConfig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace incodityReservation.Infrastructure.Persistence
{
    public class SqlServerApplicationDb : IdentityDbContext<User,Role,long,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>, IApplicationDb
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SqlServerApplicationDb(DbContextOptions<SqlServerApplicationDb> option, IHttpContextAccessor contextAccessor):base(option)
        {
            _contextAccessor = contextAccessor;
        }

        /* Comment
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.;Database=incodityRSVdb;Integrated Security=True;TrustServerCertificate=True");
        }
        */

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
            modelBuilder.OnCreatedAt();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CityConfig).Assembly);
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<ImageLibrary> ImageLibraries { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                if (ChangeTracker.HasChanges())
                {
                    foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                    {
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                entry.Entity.CreateByIpAddress = Extensions.GetUserIPAddress(_contextAccessor.HttpContext);
                                entry.Entity.CreatedByBrowser = Extensions.GetUserBrowserName(_contextAccessor.HttpContext);
                                break;
                            case EntityState.Modified:
                                entry.Entity.UpdatedAt = DateTime.Now;
                                break;
                        }
                    }
                }
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                CleanContext();
                throw ex;
            }
        }


        void CleanContext()
        {
            if (ChangeTracker.HasChanges())
            {
                var _list = this.ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted || p.State == EntityState.Added || p.State == EntityState.Modified).ToList();
                foreach (var item in _list)
                {
                    _ = item.State == EntityState.Detached;
                }
            }
        }
    }


}
