using incodityReservation.Application.Dtos;
using incodityReservation.Application.Features.Cities.Queries;
using incodityReservation.Application.Features.Villas.Commands;
using incodityReservation.Application.Features.Villas.Queries;
using incodityReservation.Web.CachedFramework;
using incodityReservation.Web.CachingFramework;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace incodityReservation.Web.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class VillaController : Controller
    {
        #region Fields


        #region User Memcached 

        /*

        private readonly ISender _mediatR;
        private readonly ILogger<VillaController> _logger;
        private readonly ICacheProvider _cacheProvider;
        private readonly ICacheRepository _cacheRepository;

        public VillaController(ISender send, ILogger<VillaController> logger, ICacheRepository cacheRepository, ICacheProvider cacheProvider)
        {
            this._mediatR = send;
            _logger = logger;
            _cacheRepository = cacheRepository;
            _cacheProvider = cacheProvider;
        }

        */

        #endregion

        #region Use In Memory cached 

        /*

        private readonly ISender _mediatR;
        private readonly ILogger<VillaController> _logger;
        private readonly IMemoryCache _memoryCache;

        public VillaController(ISender send, ILogger<VillaController> logger, IMemoryCache memoryCache)
        {
            this._mediatR = send;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        */

        #endregion

        #region Use Redis for cache

        private readonly ISender _mediatR;
        private readonly ILogger<VillaController> _logger;
        //private readonly IDistributedCache _cache;

        public VillaController(ISender mediatR, ILogger<VillaController> logger/*, IDistributedCache cache*/)
        {
            _mediatR = mediatR;
            _logger = logger;
            //_cache = cache;
        }

        #endregion



        #endregion
        public async Task<IActionResult> Index(string Name="",string City="",double From=0,double To=0,int currentPage=1)
        {
            #region Use Memcached

            /*

            object result;
            if (_cacheProvider.Get<List<VillaTable>>("getallvilla") is not null)
            {
                result = _cacheProvider.Get<List<VillaTable>>("getallvilla");
            }
            else
            {
                GetAllVillaQuery query = new GetAllVillaQuery();
                result = await _mediatR.Send(query);
                _cacheRepository.Save("getallvilla", result);
            }

            */

            #endregion

            #region Use IMemory Cache

            /*

            if (_memoryCache.TryGetValue("", out List<VillaTable> cacheVillaTable))
            {
                result = cacheVillaTable;
            }
            else
            {
                //set value in memory cache
                GetAllVillaQuery query = new GetAllVillaQuery();

                result = await _mediatR.Send(query);
                _memoryCache.Set("getallvilla", result, TimeSpan.FromSeconds(5000));
            }

            */

            #endregion

            #region Use Redis for cache
            
            /*
            object result;
            string data = await _cache.GetStringAsync("getvillaList");
            if (string.IsNullOrEmpty(data))
            {
                //set data in cache
                GetAllVillaQuery query = new GetAllVillaQuery();

                result = await _mediatR.Send(query);
                data = JsonConvert.SerializeObject(result);
                var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(20000));
                await _cache.SetStringAsync("getvillaList", data, options);

            }
            else
            {
                result = JsonConvert.DeserializeObject<List<VillaTable>>(data);
            }
            */
            #endregion



            //var query = new GetAllVillaQuery();
            //query.Name = Name;
            //query.City = City;
            //query.From = from;
            //query.To = to;

            var query = new GetAllVillaModelQuery();
            query.Name = Name;
            query.City = City;
            query.From = From;
            query.To = To;
            query.CurrentPage = currentPage;

            var result = await _mediatR.Send(query);
            return View(result);
        }

        #region Create

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
            _logger.Log(LogLevel.Error, $"Error Count : {ModelState.ErrorCount} and Model State Valid is {ModelState.IsValid}");
            return View(addVilla);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var cities = await _mediatR.Send(new GetAllCityQuery());
            ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            var query = new GetVillaDetailQuery();
            query.Id = Id;
            var result = await _mediatR.Send(query);
            if (result is null) return RedirectToAction(nameof(Index));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditVillaCommand command)
        {
            await _mediatR.Send(command);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteVillaCommand();
            command.Id = Id;
            await _mediatR.Send(command);
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
