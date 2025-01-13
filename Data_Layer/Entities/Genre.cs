using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class Genre : BaseEntity
    {
        public string GenreName { get; set; }
        public ICollection<Genre> SubGenres { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
