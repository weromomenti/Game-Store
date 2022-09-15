using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCheckedOut { get; set; }
        public ICollection<int> GameIds { get; set; }
    }
}
