using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities.Configurations
{
    internal class PEGIRatingConfiguration : IEntityTypeConfiguration<PEGIRating>
    {
        public void Configure(EntityTypeBuilder<PEGIRating> builder)
        {
            builder.HasData(
                new PEGIRating { Id = 1, Name = "PEGI3" },
                new PEGIRating { Id = 2, Name = "PEGI7" },
                new PEGIRating { Id = 3, Name = "PEGI12" },
                new PEGIRating { Id = 4, Name = "PEGI16" },
                new PEGIRating { Id = 5, Name = "PEGI18" });
        }
    }
}
