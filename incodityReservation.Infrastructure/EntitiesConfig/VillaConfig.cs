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
    public class VillaConfig:IEntityTypeConfiguration<Villa>
    {
        // Fluent Api
        public void Configure(EntityTypeBuilder<Villa> builder)
        {
            // other api
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            /*
            builder.HasData(new Villa
            {
                Id=1,
                Name = "ویلای A",
                Price = 1000,
                Address = "داخل مجموعه دست چپ",
                CityId = 2,
                CreatedAt = DateTime.Now
            });
            */
        }
    }
}
