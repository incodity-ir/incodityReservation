using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Dtos;
using incodityReservation.Application.Infrastructure;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Features.Villas.Queries
{
    public class GetAllVillaQuery : IRequest<IEnumerable<VillaTable>>;
    public class GetAllVillaQueryHandler:IRequestHandler<GetAllVillaQuery,IEnumerable<VillaTable>>
    {
        private readonly IApplicationDb _dbContext;

        public GetAllVillaQueryHandler(IApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VillaTable>> Handle(GetAllVillaQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Villa>().Include(p => p.City).AsNoTracking();
           return await query.Select(p => new VillaTable
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
