using Grocery.common.Model;
using Grocery.services.Classes;
using Grocery.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllCat")]
        public IActionResult GetAllCategory()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [Authorize]
        [HttpPost]
        [Route("AddNewCategory")]
        public IActionResult AddNewCategory(CategoryModel categoryModel)
        {
            try
            {
            _categoryService.AddNewCategory(categoryModel);
                return Ok("Category Added Succesfully");
            }catch (Exception)
            {
                return BadRequest("Category Already Exist");
            }
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(CategoryModelUpdate categoryModelUpdate)
        {
            try
            {
                _categoryService.UpdateCategory(categoryModelUpdate);
                return Ok("Category Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "ENTETRED ID DOES NOT EXIST.");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return Ok("Category Deleted Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Category with this id does not exist");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetCateogrydById(int id)
        {
            try
            {
                var brand = _categoryService.GetCategoryById(id);
                return Ok(brand);
            }
            catch (ArgumentException ex)
            {
                return NotFound("Entered id does not exist in this context");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Entered id does not exist in this context");
            }
        }

    }
}
