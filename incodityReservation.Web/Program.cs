using Enyim.Caching.Configuration;
using incodityReservation.Application;
using incodityReservation.Application.Middlewares;
using incodityReservation.Infrastructure;
using incodityReservation.Web.CachedFramework;
using incodityReservation.Web.CachingFramework;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.InfrastructureConfiguration(builder.Configuration);
builder.Services.Configuration();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(opt =>
    {
        app.UseMiddleware<ExceptionMiddleware>();
    });
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.Configure();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
