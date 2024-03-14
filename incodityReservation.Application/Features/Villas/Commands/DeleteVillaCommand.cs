using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Features.Villas.Commands
{
    /// <summary>
    /// حذف ویلا بر اساس شناسه
    /// </summary>
    public class DeleteVillaCommand:IRequest<Unit>
    {
        //شناسه ویلا
        public int Id { get; set; }
    }

    public class DeleteVillaCommandHandler:IRequestHandler<DeleteVillaCommand,Unit>
    {
        private readonly IApplicationDb _dbContext;

        public DeleteVillaCommandHandler(IApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteVillaCommand request, CancellationToken cancellationToken)
        {
            var obj = await _dbContext.Set<Villa>().FirstOrDefaultAsync(p => p.Id == request.Id);
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            _dbContext.Set<Villa>().Remove(obj);
            _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
