using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace incodityReservation.Infrastructure.EntitiesConfig
{
    public class CityConfig:IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            
            //builder.HasData(SeedCities);
        }
        /*
        // Seed Data
        public IEnumerable<City> SeedCities => new List<City>
        {
            new()
            {
                Id=1,
                Name = "چادگان",
                ProvinceId = 1,
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id=2,
                Name = "باغ بهادران",
                ProvinceId = 1,
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id=3,
                Name = "سمیرم",
                ProvinceId = 1,
                CreatedAt = DateTime.Now
            }


        };
        */
    }
}
