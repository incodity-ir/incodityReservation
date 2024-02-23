using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Application.Contracts;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Services
{
    public class CityRepository:ICityRepository
    {
        #region Fileds

        private readonly IApplicationDb dbContext;

        public CityRepository(IApplicationDb dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        public async Task<IEnumerable<City>> GetAll() => await dbContext.Set<City>().ToListAsync();

        public async Task<City> GetById(int id) => await dbContext.Set<City>().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> Create(City entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
               await dbContext.Set<City>().AddAsync(entity);
               await dbContext.SaveChangesAsync();
               return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(City entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                dbContext.Set<City>().Update(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task DeleteById(int id)
        {
            var entity = await GetById(id);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Delete(entity);
        }

        public async Task<bool> Delete(City entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                dbContext.Set<City>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<City> Table => dbContext.Set<City>();
        public IQueryable<City> TableAsNoTracking => dbContext.Set<City>().AsNoTracking();
    }
}
