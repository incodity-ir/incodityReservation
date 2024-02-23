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
    public class ProvinceRepository:IProvinceRepository
    {
        #region Feilds

        private readonly IApplicationDb dbContext;

        public ProvinceRepository(IApplicationDb dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        public async Task<IEnumerable<Province>> GetAll() => await dbContext.Set<Province>().ToListAsync();

        public async Task<Province> GetById(int id) => await dbContext.Set<Province>().FirstOrDefaultAsync(p=>p.Id == id);

        public async Task<bool> Create(Province entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                await dbContext.Set<Province>().AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Province entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                dbContext.Set<Province>().Update(entity);
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

        public async Task<bool> Delete(Province entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            try
            {
                dbContext.Set<Province>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Province> Table => dbContext.Set<Province>();
        public IQueryable<Province> TableAsNoTracking => dbContext.Set<Province>().AsNoTracking();
    }
}
