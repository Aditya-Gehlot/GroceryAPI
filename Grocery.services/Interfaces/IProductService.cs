using Grocery.common.Model;
using Grocery.Common.Model;

namespace Grocery.services.Interfaces
{
    public interface IProductService
    {
        List<ShowProductModel> GetAllProducts();
        void AddNewProduct(ProductModel productModel);
        void UpdateProduct(ProductModelUpdate productModelUpdate);
        void DeleteProduct(int id);
        ProductModel GetProductById(int id);
        List<ShowProductModel> GetProductOfBrand(int id);
        List<ShowProductModel> GetProductOfCategory(int id);


    }
}
