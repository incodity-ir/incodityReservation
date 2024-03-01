using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using incodityReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace incodityReservation.Infrastructure.EntitiesConfig
{
    //? Fluent Api 
    public class ImageLibraryConfig:IEntityTypeConfiguration<ImageLibrary>
    {
        public void Configure(EntityTypeBuilder<ImageLibrary> builder)
        {
            builder.HasOne(p => p.Villa) // each villa can have many photos
                .WithMany(p => p.ImageLibraries) // each image can have only one villa id
                .HasForeignKey(p => p.VillaId) // the key connected villa and image library tables
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
