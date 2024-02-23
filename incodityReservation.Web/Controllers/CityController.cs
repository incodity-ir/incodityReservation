using incodityReservation.Application.Contracts;
using incodityReservation.Domain;
using Microsoft.AspNetCore.Mvc;

namespace incodityReservation.Web.Controllers
{

    public class CityController : Controller
    {
        #region Fileds

        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        #endregion

        
        public async Task<IActionResult> Index()
        {
            var list = await _cityRepository.GetAllCities();
            return View(list);
        }

        public async Task<IActionResult> Create(City city)
        {
            return View();
        }
    }
}
