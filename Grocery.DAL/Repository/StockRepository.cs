using Grocery.common.Entities;
using Grocery.DAL.Interfaces;

namespace Grocery.DAL.Classes
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StockEntity> GetAllStocksFromDb()
        {
            return _dbContext.StockTable.ToList();
        }

        public void AddNewStockToDb(StockEntity stockEntity)
        {
            _dbContext.StockTable.Add(stockEntity);
            _dbContext.SaveChanges();
        }

        public void DeleteStockFromDb(int id)
        {
            var stock = _dbContext.StockTable.Find(id);
            _dbContext.StockTable.Remove(stock);
            _dbContext.SaveChanges();

        }

        public StockEntity GetStockById(int id)
        {
            return _dbContext.StockTable.FirstOrDefault(s => s.stock_id == id);
        }

        public void UpdateStockInDb(StockEntity stockEntity)
        {
            _dbContext.StockTable.Update(stockEntity);
            _dbContext.SaveChanges();
        }


        public StockEntity GetStockByProductId(int id)
        {
            return _dbContext.StockTable.FirstOrDefault(s => s.product_id == id);
        }


        public void AddStockFromProduct(ProductEntity productEntity, int current_product_id)
        {
            var stockEntity = new StockEntity
            {
                product_id = current_product_id,
                product_name = productEntity.product_name,
                produt_quantity = productEntity.produt_quantity
            };
            _dbContext.StockTable.Add(stockEntity);
            _dbContext.SaveChanges();
        }

        public void UpdateStock(StockEntity stockEntity) {
            _dbContext.StockTable.Update(stockEntity);
            _dbContext.SaveChanges();

        }
    }
}
