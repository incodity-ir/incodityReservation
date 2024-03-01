using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace incodityReservation.Application.Dtos
{
    public interface IDateDto<TType>
    {
        TType CreatedAt { get; set; }
        TType? UpdatedAt { get; set; }
        TType? DeletedAt { get; set;}
        bool IsDeleted { get; set; }
    }
}
