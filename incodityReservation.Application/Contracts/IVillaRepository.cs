using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;

namespace incodityReservation.Application.Contracts
{
    public interface IVillaRepository:IRepository<Villa>
    {
        Task<IEnumerable<Villa>> FilterByCity(string cityName);
    }
}
