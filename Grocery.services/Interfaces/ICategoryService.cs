using Grocery.common.Entities;
using Grocery.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModelUpdate> GetAllCategories();
        void AddNewCategory(CategoryModel categoryModel);
        void UpdateCategory(CategoryModelUpdate categoryModelUpdate);
        void DeleteCategory(int id);
        public CategoryModel GetCategoryById(int id);
    }
}
