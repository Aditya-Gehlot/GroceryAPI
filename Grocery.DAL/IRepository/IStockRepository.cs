using Grocery.common.Entities;
using Grocery.common.Model;

namespace Grocery.DAL.Interfaces
{
    public interface IStockRepository
    {
        List<StockEntity> GetAllStocksFromDb();
        void AddNewStockToDb(StockEntity stockEntity);
        void DeleteStockFromDb(int id);
        StockEntity GetStockById(int id);
        void UpdateStockInDb(StockEntity stockEntity);
        void AddStockFromProduct(ProductEntity productEntity, int id);
        public StockEntity GetStockByProductId(int id);

        public void UpdateStock(StockEntity stockEntity);
    }
}