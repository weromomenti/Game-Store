using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre { Id = 1, GenreName = "Strategy" },
                new Genre { Id = 2, GenreName = "RPG" },
                new Genre { Id = 3, GenreName = "Sport" },
                new Genre { Id = 4, GenreName = "Racing" },
                new Genre { Id = 5, GenreName = "Action" },
                new Genre { Id = 6, GenreName = "Adventure" },
                new Genre { Id = 7, GenreName = "Puzzle & Skill" },
                new Genre { Id = 8, GenreName = "Other" });
        }
    }
}
