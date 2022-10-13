using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public ICollection<int> SubgenreIds { get; set; }
    }
}
