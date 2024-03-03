using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using incodityReservation.Application.Dtos;
using incodityReservation.Application.Infrastructure;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using MediatR;

namespace incodityReservation.Application.Features.Villas.Commands
{
    /// <summary>
    /// افزودن ویلای جدید
    /// </summary>
    public class CreateVillaCommand : IRequest<Unit>
    {
        public AddVillaDto villa { get; set; }
    }

    public class CreateVillaCommandHandler : IRequestHandler<CreateVillaCommand,Unit>
    {
        private readonly IApplicationDb _dbContext;
        private readonly IMapper _mapper;

        // Dependency Injection : Constructor Injection 
        public CreateVillaCommandHandler(IApplicationDb dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateVillaCommand request, CancellationToken cancellationToken)
        {
            Villa villa = new()
            {
                Name = request.villa.Name,
                CityId = request.villa.CityId,
                Description = request.villa.Description,
                Price = request.villa.Price,
                Address = request.villa.Address,
                StartDate = request.villa.StartDate.PersianToMiladi(),
                ExpireDate = request.villa.ExpireDate.PersianToMiladi()
            };
            villa.ImageBytes = await request.villa.ImageBytes.ConvertImageToByte();
            if (villa == null) throw new ArgumentNullException(nameof(villa));
            await _dbContext.Set<Villa>().AddAsync(villa);
            await _dbContext.SaveChangesAsync(); // add new villa
            return Unit.Value;
        }
    }
}
