using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using incodityReservation.Application.Dtos;
using incodityReservation.Application.Infrastructure;
using incodityReservation.Application.Models;
using incodityReservation.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Features.Villas.Queries
{
    
    public class GetAllVillaModelQuery:SearchVillaModel,IRequest<SearchVillaModel>{}

    public class GetAllVillaModelQueryHandler : IRequestHandler<GetAllVillaModelQuery, SearchVillaModel>
    {
        private readonly IApplicationDb _dbContext;

        public GetAllVillaModelQueryHandler(IApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SearchVillaModel> Handle(GetAllVillaModelQuery request, CancellationToken cancellationToken)
        {
            SearchVillaModel _model = new();
            _model.Name = request.Name;
            _model.City = request.City;
            _model.From = request.From;
            _model.To = request.To;

            var query = _dbContext.Villas.Include(p=>p.City).Where(p => !p.IsDeleted).AsQueryable();
            
            if (!string.IsNullOrEmpty(_model.Name))
            {
                query = query.Where(p => p.Name.Contains(_model.Name));
            }

            if (!string.IsNullOrEmpty(_model.City))
            {
                query = query.Where(p => p.City.Name.Contains(_model.City));
            }

            if (_model.From > 0)
            {
                query = query.Where(p => p.Price>= _model.From);
            }

            if (_model.To > 0)
            {
                query = query.Where(p => p.Price <= _model.To);
            }

            int totalRecords = query.Count();
            int pageSize = 2;
            int totalPages = (int) Math.Ceiling(totalRecords / (double)pageSize);

            query = query.Skip((request.CurrentPage-1) * pageSize).Take(pageSize);

            _model.PageSize = pageSize;
            _model.CurrentPage = request.CurrentPage;
            _model.TotalPages = totalPages;

            _model.Data = await query.Select(p => new VillaTableDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageBytes = p.ImageBytes,
                CityName = p.City.Name,
                ExpireDate = p.ExpireDate.ToPersian(),
                StartDate = p.StartDate.ToPersian()

            }).ToListAsync();

            return _model;
        }
    }
    
}
