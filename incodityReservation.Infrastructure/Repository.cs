using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IApplicationDb dbContext;
        

        public Repository(IApplicationDb dbContext)
        {
            this.dbContext = dbContext;
        }


        private DbSet<TEntity> entities;
        private DbSet<TEntity> Entities => (entities is null) ? dbContext.Set<TEntity>() : entities;
        public IQueryable<TEntity> Table => Entities; // IQueryable<City> Table 

        public IQueryable<TEntity> TableAsNoTracking => Entities.AsNoTracking();



        public async Task<bool> Create(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            try
            {
                await dbContext.Set<TEntity>().AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task DeleteById(int id)
        {
            var entity = await GetById(id);
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            await Delete(entity);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            try
            {
                dbContext.Set<TEntity>().Remove(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<IEnumerable<TEntity>> GetAll()=>await dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetById(int id) => await dbContext.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> Update(TEntity entity)
        {
            if(entity is null) throw new ArgumentNullException( nameof(entity));
            try
            {
                dbContext.Set<TEntity>().Update(entity);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
