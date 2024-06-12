using Grocery.common.Entities;
using Grocery.DAL.Interfaces;
namespace Grocery.DAL.Classes
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductEntity> GetAllProductsFromDb()
        {
            return _dbContext.ProductTable.ToList();
        }


        public void AddNewProductToDb(ProductEntity productEntity,StockEntity stockEntity )
        {
            _dbContext.ProductTable.Add(productEntity); 
           _dbContext.StockTable.Add(stockEntity);
            _dbContext.SaveChanges();
        }


        public void UpdateProductInDb(ProductEntity productEntity,StockEntity stockEntity)
        {       
            _dbContext.ProductTable.Update(productEntity);
            _dbContext.StockTable.Update(stockEntity);
            _dbContext.SaveChanges();
        }

        public void DeleteProductFromDb(int id)
        {
            var product = _dbContext.ProductTable.FirstOrDefault(p => p.product_id == id);
            var stock = _dbContext.StockTable.FirstOrDefault(s => s.product_id == product.product_id);
            _dbContext.ProductTable.Remove(product);
            _dbContext.StockTable.Remove(stock);
            _dbContext.SaveChanges();
        }

        public ProductEntity GetProductById(int id)
        {
            return _dbContext.ProductTable.FirstOrDefault(b => b.product_id == id);
        }
        public int GetProductId()
        {
            return _dbContext.ProductTable.Max(c => c.product_id);
        }

        public bool IsProductExist(int id)
        { 
            return _dbContext.ProductTable.Any(p => p.product_id == id);
        }
        public bool IsProductExist(string name)
        {
            return _dbContext.ProductTable.Any(p => p.product_name == name);
        }
        public ProductEntity GetProductId(int id) {
            return _dbContext.ProductTable.FirstOrDefault(p =>p.product_id==id);
         }

        public void UpdateProductFromStock(ProductEntity productEntity)
        {
            _dbContext.ProductTable.Update(productEntity);
            _dbContext.SaveChanges();
        }

        public List<ProductEntity> GetProductOfBrand(int id)
        {
            return _dbContext.ProductTable.Where(p => p.brand_id == id).ToList();
        }

        public List<ProductEntity> GetProductOfCategory(int id)
        {
            return _dbContext.ProductTable.Where(p => p.category_id == id).ToList();
        }
    }
}
