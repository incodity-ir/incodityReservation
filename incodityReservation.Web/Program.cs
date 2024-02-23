using incodityReservation.Infrastructure;
using incodityReservation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region IoC : Inversion of Controller


builder.Services.AddDbContext<IApplicationDb, SqlServerApplicationDb>(option =>
{
    // Type 1
    //option.UseSqlServer("Server=.;Database=incodityRSVdb;Integrated Security=True;TrustServerCertificate=True;");

    // Type 2
    option.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"));

    // Type 3
    //option.UseSqlServer(builder.Configuration["DatbaseConnections:Appdb"]);
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
