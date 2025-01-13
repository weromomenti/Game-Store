using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Entities
{
    public class OrderDetails : BaseEntity
    {
        public int GameId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Game? Game { get; set; }
        public Order? Order { get; set; }
    }
}
