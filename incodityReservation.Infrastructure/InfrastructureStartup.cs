using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain.Entities.Security;
using incodityReservation.Infrastructure.Features;
using incodityReservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace incodityReservation.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static void InfrastructureConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContextPool<IApplicationDb, SqlServerApplicationDb>((sp, option) =>
            {
                option.UseSqlServer(configuration.GetConnectionString("AppDb")).AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>());
            }, poolSize: 16);
        }
    }
}
