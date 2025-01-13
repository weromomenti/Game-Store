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
                new PEGIRating { Id = 1, RatingName = "PEGI3" },
                new PEGIRating { Id = 2, RatingName = "PEGI7" },
                new PEGIRating { Id = 3, RatingName = "PEGI12" },
                new PEGIRating { Id = 4, RatingName = "PEGI16" },
                new PEGIRating { Id = 5, RatingName = "PEGI18" });
        }
    }
}
