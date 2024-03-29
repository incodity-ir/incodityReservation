﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Dtos;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;

namespace incodityReservation.Application.Contracts
{
    public interface ICityRepository:IRepository<City>
    {
        Task<bool> Create(CreateCityDto city);
        Task<List<CityDto>> GetCitySummery();
        Task<List<CityForShowDto>> GetAllCities();
    }
}
