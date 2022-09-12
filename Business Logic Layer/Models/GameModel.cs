﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    internal class GameModel
    {
        public int Id { get; set; }
        public int PEGIRatingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ICollection<int> GenreIds { get; set; }
        public ICollection<int> CommentIds { get; set; }
    }
}
