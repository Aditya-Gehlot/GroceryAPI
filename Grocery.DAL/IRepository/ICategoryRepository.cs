using Grocery.common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        List<CategoryEntity> GetAllCategoriesFromDb();
        void AddNewCategoryToDb(CategoryEntity categoryEntity);
        void UpdateCategoryInDb(CategoryEntity categoryEntity);
        void DeleteCategoryFromDb(int id);
        public CategoryEntity GetCategoryById(int id);
        bool IsExistById(int categoryId);
        bool IsExistByName(string categoryname);
        string GetCategoryName(int id); 


    }
}
