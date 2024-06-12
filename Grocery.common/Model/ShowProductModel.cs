using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Common.Model
{
    public class ShowProductModel
    {

        public int product_id { get; set; }
        public string? product_name { get; set; }
        public int category_id { get; set; }
        public string? category_name { get; set; }
        public int brand_id { get; set; }
        public string? brand_name { get; set; }
        //   public int product_price { get; set; }

        public int produt_quantity { get; set; }
    }
}
