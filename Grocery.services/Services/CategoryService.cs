using AutoMapper;
using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.DAL.Classes;
using Grocery.DAL.Interfaces;
using Grocery.services.Interfaces;

namespace Grocery.services.Classes
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryDataAccess, IMapper mapper)
        {
            _categoryRepository = categoryDataAccess;
            _mapper = mapper;
        }

        public List<CategoryModelUpdate> GetAllCategories()
        {
            var categories = _categoryRepository.GetAllCategoriesFromDb();
            var category = _mapper.Map<List<CategoryModelUpdate>>(categories);
            return category;
        }

        public void AddNewCategory(CategoryModel categoryModel)
        {
            var categoryexist = _categoryRepository.IsExistByName(categoryModel.category_name);
            if (categoryexist)
            {
                throw new Exception("Category Already Exist");
            }
            var categoryEntity = _mapper.Map<CategoryEntity>(categoryModel);
            _categoryRepository.AddNewCategoryToDb(categoryEntity);
        }

        public void UpdateCategory(CategoryModelUpdate categoryModelUpdate)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(categoryModelUpdate);
            var brand = _categoryRepository.IsExistById(categoryEntity.categopry_id);
            if(!brand)
            {
                throw new Exception("Wrong category id. ");
            }
            _categoryRepository.UpdateCategoryInDb(categoryEntity);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategoryFromDb(id);
        }

        public CategoryModel GetCategoryById(int id)
        {
            var categoryEntity = _categoryRepository.GetCategoryById(id);
            if (categoryEntity == null)
            {
                throw new ArgumentException("Category not found");
            }
            return _mapper.Map<CategoryModel>(categoryEntity);
        }
    }
}
