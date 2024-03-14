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
    /// <summary>
    /// فراخوانی اطلاعات ویلا بر اساس شناسه
    /// </summary>
    public class GetVillaDetailQuery:IRequest<EditVillaDto>
    {
        //شناسه ویلا
        public int Id { get; set; }
    }

    public class GetVillaDetailQueryHandler :IRequestHandler<GetVillaDetailQuery,EditVillaDto>
    {
        public readonly IApplicationDb _dbContext;

        public GetVillaDetailQueryHandler(IApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<EditVillaDto> Handle(GetVillaDetailQuery request, CancellationToken cancellationToken)
        {
            var obj = await _dbContext.Set<Villa>().FirstOrDefaultAsync(p => p.Id == request.Id);
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var villa = new EditVillaDto()
            {
                Name = obj.Name,
                CityId = obj.CityId,
                Address = obj.Address,
                Description = obj.Description,
                ExpireDate = obj.ExpireDate.ToPersian(),
                StartDate = obj.StartDate.ToPersian(),
                ImageBytes = null,
                Price = obj.Price,
                Id = obj.Id
            };

            return villa;
        }
    }
}
