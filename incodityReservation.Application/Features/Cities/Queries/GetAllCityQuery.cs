using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using incodityReservation.Application.Dtos;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Features.Cities.Queries
{
    /// <summary>
    /// دریافت لیست کلیه شهرها
    /// </summary>
    public class GetAllCityQuery : IRequest<List<CityDto>>;

    public class GetAllCityQueryHandler : IRequestHandler<GetAllCityQuery, List<CityDto>>
    {
        private readonly IApplicationDb _dbContext;
        private readonly IMapper _mapper;

        public GetAllCityQueryHandler(IApplicationDb dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<City>().AsNoTracking().Select(p=>new CityDto
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl
            }).ToListAsync();
        }
    }
}
