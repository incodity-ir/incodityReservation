using System.Diagnostics;
using incodityReservation.Application.Dtos;
using incodityReservation.Application.Services;
using incodityReservation.Infrastructure;
using incodityReservation.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using incodityReservation.Web.Models;

namespace incodityReservation.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IApplicationDb dbcontext;
    private readonly IUserService userService;

    public HomeController(ILogger<HomeController> logger, IApplicationDb dbcontext, IUserService userService)
    {
        _logger = logger;
        this.dbcontext = dbcontext;
        this.userService = userService;
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

    [HttpGet]
    public  async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserDto userDto)
    {
        if (ModelState.IsValid)
        {
            await userService.Register(userDto);
        }

        return View();
    }
}
