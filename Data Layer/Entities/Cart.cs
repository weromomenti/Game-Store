using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCheckedOut { get; set; }
        public ICollection<Game> Games { get; set; }
        public User User { get; set; }
    }
}
