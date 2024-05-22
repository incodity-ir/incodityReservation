using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Contracts;
using incodityReservation.Application.Mapping;
using incodityReservation.Application.Middlewares;
using incodityReservation.Application.Services;
using incodityReservation.Domain.Entities.Security;
using incodityReservation.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Hosting;

namespace incodityReservation.Application
{
    public static class CommonStratup
    {
        public static void Configuration(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var mapper = ConfigMapping.ConfigMap().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IVillaRepository, VillaRepository>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IErrorHandler, ErrorHandler>();

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<SqlServerApplicationDb>().AddDefaultTokenProviders();


            #region Use InMemory Cahced

            //builder.Services.AddMemoryCache();

            #endregion

            #region Use Memcached
            /*
            builder.Services.AddEnyimMemcached(c =>
                c.Servers = new List<Server> { new Server { Address = "localhost", Port = 11211 } });
            builder.Services.TryAddSingleton<ICacheProvider, CacheProvider>();
            builder.Services.TryAddSingleton<ICacheRepository, CacheRepository>();
            */
            #endregion

            #region Use Redis for cached 

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "127.0.0.1:6379";
                option.InstanceName = "incodity";
            });

            #endregion

        }

        public static void Configure(this IApplicationBuilder app)
        {
           
            /*
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(opt =>
                {
                    app.UseMiddleware<ExceptionMiddleware>();
                });
                app.UseHsts();
            }
            */
            /*
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            */
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
        }
        
    }
}
