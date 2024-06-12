namespace Grocery.common.Model
{
    public class ProductModel
    {
        public string? product_name { get; set; }
        public int category_id { get; set; }
        
     //  public string? category_name { get; set; }
        public int brand_id { get; set; }
        
     //   public string? brand_name { get; set; }
        
       public int product_price { get; set; }
        public int produt_quantity { get; set; }

        public DateTime CreatedAtDate { get; set; }


    }
}
