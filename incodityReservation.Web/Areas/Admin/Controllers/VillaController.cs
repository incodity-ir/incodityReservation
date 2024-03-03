using incodityReservation.Application.Dtos;
using incodityReservation.Application.Features.Cities.Queries;
using incodityReservation.Application.Features.Villas.Commands;
using incodityReservation.Application.Features.Villas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace incodityReservation.Web.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class VillaController : Controller
    {
        #region Fields

        private readonly ISender _mediatR;
        private readonly ILogger<VillaController> _logger;

        public VillaController(ISender send, ILogger<VillaController> logger)
        {
            this._mediatR = send;
            _logger = logger;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
             GetAllVillaQuery query = new GetAllVillaQuery();
            var result = await _mediatR.Send(query);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var result = await _mediatR.Send(new GetAllCityQuery());
            ViewData["Cities"] = new SelectList(result, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddVillaDto addVilla)
        {
            if (ModelState.IsValid)
            {
                CreateVillaCommand command = new CreateVillaCommand();
                command.villa = addVilla;
                await _mediatR.Send(command);
                return RedirectToAction(nameof(Index));
            }
            _logger.Log(LogLevel.Error,$"Error Count : {ModelState.ErrorCount} and Model State Valid is {ModelState.IsValid}");
            return View(addVilla);
        }
    }
}
