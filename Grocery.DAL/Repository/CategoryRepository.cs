using Grocery.common.Entities;
using Grocery.DAL.Interfaces;

namespace Grocery.DAL.Classes
{
    public class CategoryRepository:ICategoryRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryEntity> GetAllCategoriesFromDb()
        {
            return _dbContext.CategoryTable.ToList();
        }

        public void AddNewCategoryToDb(CategoryEntity categoryEntity)
        {
            _dbContext.CategoryTable.Add(categoryEntity);
            _dbContext.SaveChanges();
        }

        public void UpdateCategoryInDb(CategoryEntity categoryEntity)
        {
           // var category = _dbContext.CategoryTable.Find(categoryEntity.categopry_id);
            _dbContext.CategoryTable.Update(categoryEntity); 
            _dbContext.SaveChanges();
        }

        public void DeleteCategoryFromDb(int id)
        {
            var category = _dbContext.CategoryTable.Find(id);
            _dbContext.CategoryTable.Remove(category);
            _dbContext.SaveChanges();

        }
        public CategoryEntity GetCategoryById(int id)
        {
            return _dbContext.CategoryTable.FirstOrDefault(b => b.categopry_id == id);
        }

        public bool IsExistById(int categoryId)
        {
            return _dbContext.CategoryTable.Any(c => c.categopry_id == categoryId);
        }
        public bool IsExistByName(string categoryname)
        {
            return _dbContext.CategoryTable.Any(c => c.category_name == categoryname);
        }
        public string GetCategoryName(int id)
        {
            var category= _dbContext.CategoryTable.FirstOrDefault(p => p.categopry_id == id);
            return category.category_name;
        }


    }
}
