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
    public class ProvinceConfig:IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasData(new Province
            {
                Id=1,
                Name = "اصفهان",
                CreatedAt = DateTime.Now,
            });
        }
    }
}
