using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;

namespace incodityReservation.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task DeleteById(int id);
        Task<bool> Delete(TEntity entity);

        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableAsNoTracking { get; }
    }
}
