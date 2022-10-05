using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class SearchModel
    {
        [MinLength(3)]
        public string? Title { get; set; }
        public string[]? Genre { get; set; }
    }
}
