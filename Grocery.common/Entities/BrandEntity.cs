using System.ComponentModel.DataAnnotations;

namespace Grocery.common.Entities
{
    public class BrandEntity
    {
        [Key]
        public int brand_id { get; set; }
        public string? brand_name { get; set; }
    }
}
