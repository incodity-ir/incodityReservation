using incodityReservation.Application.Dtos;
using incodityReservation.Application.Features.Cities.Queries;
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

        public VillaController(ISender send)
        {
            this._mediatR = send;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
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
            return View();
        }
    }
}
