using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using incodityReservation.Application.Dtos;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using MediatR;

namespace incodityReservation.Application.Features.Villas.Commands
{
    /// <summary>
    /// افزودن ویلای جدید
    /// </summary>
    public class CreateVillaCommand :AddVillaDto, IRequest<VillaDto>;

    public class CreateVillaCommandHandler : IRequestHandler<CreateVillaCommand,VillaDto>
    {
        private readonly IApplicationDb _dbContext;
        private readonly IMapper _mapper;

        // Dependency Injection : Constructor Injection 
        public CreateVillaCommandHandler(IApplicationDb dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<VillaDto> Handle(CreateVillaCommand request, CancellationToken cancellationToken)
        {
            var villa = _mapper.Map<Villa>(request);
            if (villa == null) throw new ArgumentNullException(nameof(villa));
            await _dbContext.Set<Villa>().AddAsync(villa);
            await _dbContext.SaveChangesAsync(); // add new villa
            return _mapper.Map<VillaDto>(villa);
        }
    }
}
