using System.Diagnostics;
using incodityReservation.Infrastructure;
using incodityReservation.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using incodityReservation.Web.Models;

namespace incodityReservation.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IApplicationDb dbcontext;
    public HomeController(ILogger<HomeController> logger, SqlServerApplicationDb dbcontext)
    {
        _logger = logger;
        this.dbcontext = dbcontext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
