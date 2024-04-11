using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Dtos;
using incodityReservation.Application.Infrastructure;
using incodityReservation.Application.Models;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Features.Villas.Queries
{
    
    public class GetAllVillaQuery : SearchVillaModel, IRequest<IEnumerable<VillaTableDto>>;
    public class GetAllVillaQueryHandler:IRequestHandler<GetAllVillaQuery,IEnumerable<VillaTableDto>>
    {
        private readonly IApplicationDb _dbContext;

        public GetAllVillaQueryHandler(IApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VillaTableDto>> Handle(GetAllVillaQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Villa>().Include(p => p.City).Where(p=>!p.IsDeleted);

            if (!string.IsNullOrEmpty(request.Name))
            {
               query = query.Where(p => p.Name.Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request.City))
            {
                query = query.Where(p => p.City.Name.Contains(request.City));
            }

            if (request.From != 0)
            {
                query = query.Where(p => p.Price >= request.From);
            }

            if (request.To != 0)
            {
                query = query.Where(p => p.Price <= request.To);
            }

            return await query.AsNoTracking().Select(p => new VillaTableDto
            {
                Id = p.Id,
                Name = p.Name,
                CityName = p.City.Name,
                Price = p.Price,
                ImageBytes = p.ImageBytes,
                ExpireDate = p.ExpireDate.ToPersian(),
                StartDate = p.StartDate.ToPersian()
            }).ToListAsync();
        }
    }
    
}
