using Grocery.common.Entities;
using Grocery.DAL.Interfaces;

namespace Grocery.DAL.Classes
{
    public class BrandRepository:IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BrandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BrandEntity> GetAllBrandsFromDb()
        {
            return _dbContext.BrandTable.ToList();
        }

        public void AddNewBrandToDb(BrandEntity brandEntity)
        {
            _dbContext.BrandTable.Add(brandEntity);
            _dbContext.SaveChanges();
        }
        public void DeleteBrandFromDb(int id)
        {
            var brand = _dbContext.BrandTable.Find(id);
            _dbContext.BrandTable.Remove(brand);
            _dbContext.SaveChanges();
        }

        public BrandEntity GetBrandById(int id)
        {
            return _dbContext.BrandTable.FirstOrDefault(b => b.brand_id == id);
        }

        public void UpdateBrandInDb(BrandEntity brandEntity)
        {
           // var brand = _dbContext.BrandTable.Find(brandEntity.brand_id);
            _dbContext.BrandTable.Update(brandEntity);
            _dbContext.SaveChanges();
        }

        public bool IsExistById(int brandId) { 
        return _dbContext.BrandTable.Any(c => c.brand_id == brandId);
        }
        public bool IsExistByName(string name) {  
            return _dbContext.BrandTable.Any(c=> c.brand_name == name);
        }
        public string GetBrandName(int id)
        {
           var brand = _dbContext.BrandTable.FirstOrDefault(p => p.brand_id == id);
           return brand.brand_name;
        }
    }
}
