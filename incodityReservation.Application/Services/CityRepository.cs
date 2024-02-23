using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using incodityReservation.Application.Contracts;
using incodityReservation.Application.Dtos;
using incodityReservation.Domain;
using incodityReservation.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace incodityReservation.Application.Services
{
    public class CityRepository:ICityRepository
    {
        #region Fileds

        private readonly IApplicationDb dbContext;
        private readonly IMapper mapper;

        public CityRepository(IApplicationDb dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        #endregion

        public async Task<IEnumerable<City>> GetAll() => await dbContext.Set<City>().Include(p=>p.Province).ToListAsync();

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
        public async Task<bool> Create(CreateCityDto city)
        {
            try
            {
                // 1
                City c = new()
                {
                    Name = city.Name,
                    ProvinceId = city.ProvinceId
                };
                await dbContext.Set<City>().AddAsync(c);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<List<CityDto>> GetCitySummery()
        {
           return TableAsNoTracking.Select(p => new CityDto
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl
            }).ToListAsync();
        }

        public async Task<List<CityForShowDto>> GetAllCities()
        {
            /*return await dbContext.Set<City>().Include(p => p.Province).Select(p => new CityForShowDto
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                ProvinceName = p.Province.Name
            }).ToListAsync();
            */
            var list = await TableAsNoTracking.ToListAsync();
            return mapper.Map<List<CityForShowDto>>(list);
        }
    }
}
