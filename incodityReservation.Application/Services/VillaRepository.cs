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
    public class VillaRepository:IVillaRepository
    {
        #region Fileds

        private readonly IApplicationDb dbContext;

        public VillaRepository(IApplicationDb dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        public async Task<IEnumerable<Villa>> GetAll() => await dbContext.Set<Villa>().ToListAsync();


        public async Task<Villa> GetById(int id) => await dbContext.Set<Villa>().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> Create(Villa entity)
        {
            try
            {
                await dbContext.Set<Villa>().AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Update(Villa entity)
        {
            try
            {
                dbContext.Set<Villa>().Update(entity);
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
            var villa = await GetById(id);
            if (villa == null) throw new ArgumentNullException(nameof(villa));
            var result = await Delete(villa);
        }

        public async Task<bool> Delete(Villa entity)
        {
            try
            {
                dbContext.Set<Villa>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Villa> Table => dbContext.Set<Villa>();
        public IQueryable<Villa> TableAsNoTracking => dbContext.Set<Villa>().AsNoTracking();
        public async Task<IEnumerable<Villa>> FilterByCity(string cityName)
        {
            return await  TableAsNoTracking.Include(p=>p.City).Where(p => p.City.Name.Contains(cityName)).ToListAsync();
        }
    }
}
