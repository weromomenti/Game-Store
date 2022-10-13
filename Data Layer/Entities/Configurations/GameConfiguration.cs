using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
                new Game { Id = 1, Name = "The Witcher 3: Wild Hunt", Description = "Description", PEGIRatingId = 1, ImageUrl = "https://picfiles.alphacoders.com/198/thumb-198636.jpg", Price = 30m },
                new Game { Id = 2, Name = "Battlefield V", Description = "Description", PEGIRatingId = 2, ImageUrl = "https://m.media-amazon.com/images/I/515XvAG+q6L._AC_SY780_.jpg", Price = 40m });
        }
    }
}
