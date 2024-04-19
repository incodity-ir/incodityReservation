using Enyim.Caching.Configuration;
using incodityReservation.Application.Contracts;
using incodityReservation.Application.Mapping;
using incodityReservation.Application.Services;
using incodityReservation.Domain.Entities.Security;
using incodityReservation.Infrastructure;
using incodityReservation.Infrastructure.Features;
using incodityReservation.Infrastructure.Persistence;
using incodityReservation.Web.CachedFramework;
using incodityReservation.Web.CachingFramework;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region IoC : Inversion of Controller


builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<SoftDeleteInterceptor>();
builder.Services.AddDbContextPool<IApplicationDb, SqlServerApplicationDb>((sp,option) =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")).AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>());
},poolSize:16);
var mapper = ConfigMapping.ConfigMap().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService,UserService>();

#region Identity

//builder.Services.AddDbContext<IdentityDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"), optionBuilder =>optionBuilder.MigrationsAssembly("incodityReservation.Infrastructure"));
//});

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<SqlServerApplicationDb>().AddDefaultTokenProviders();

#endregion

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

builder.Services.AddDistributedRedisCache(option =>
{
    option.Configuration = "127.0.0.1:6379";
    option.InstanceName = "incodity";
});

#endregion


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
