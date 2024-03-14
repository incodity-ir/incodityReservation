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

namespace incodityReservation.Application.Features.Villas.Commands
{
    /// <summary>
    /// آپدیت اطلاعات ویلا
    /// </summary>
    public class EditVillaCommand : EditVillaDto, IRequest<Unit>
    {

    }

    public class EditVillaCommandHandler : IRequestHandler<EditVillaCommand,Unit>
    {
        public readonly IApplicationDb _dbContext;

        public EditVillaCommandHandler(IApplicationDb dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(EditVillaCommand request, CancellationToken cancellationToken)
        {
            var obj = await _dbContext.Set<Villa>().FirstOrDefaultAsync(p => p.Id == request.Id);
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            #region Update Feilds

            obj.Name = request.Name;
            obj.Description = request.Description;
            obj.Address = request.Address;
            obj.Price = request.Price;
            obj.StartDate = request.StartDate.PersianToMiladi();
            obj.ExpireDate = request.ExpireDate.PersianToMiladi();
            obj.CityId = request.CityId;
            obj.ImageBytes = await request.ImageBytes.ConvertImageToByte();

            #endregion

            _dbContext.Set<Villa>().Update(obj);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
