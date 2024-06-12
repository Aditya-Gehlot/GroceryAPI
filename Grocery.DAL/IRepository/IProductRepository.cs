using Grocery.common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Interfaces
{
    public interface IProductRepository
    {
        List<ProductEntity> GetAllProductsFromDb();
        void AddNewProductToDb(ProductEntity productEntity,StockEntity stockEntity);
        void UpdateProductInDb(ProductEntity productEntity,StockEntity stockEntity);
        void DeleteProductFromDb(int id);
        public ProductEntity GetProductById(int id);
        int GetProductId();

        bool IsProductExist(int id);
        bool IsProductExist(string name);
        ProductEntity GetProductId(int id);
        void UpdateProductFromStock(ProductEntity productEntity);

        List<ProductEntity> GetProductOfBrand(int id);
        List<ProductEntity> GetProductOfCategory(int id);
        // StockEntity GetStockByProductId(int productId);
        //  void AddNewStockRecord(StockEntity stockEntity);
        // void UpdateStockRecord(StockEntity stockEntity);
    }
}
