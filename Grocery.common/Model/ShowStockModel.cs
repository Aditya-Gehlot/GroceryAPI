using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Common.Model
{
    public class ShowStockModel
    {
        public int stock_id { get; set; }
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public int product_price { get; set; }
        public int produt_quantity { get; set; }
        public DateTime CreatedAtDate { get; set; }
    }
}
