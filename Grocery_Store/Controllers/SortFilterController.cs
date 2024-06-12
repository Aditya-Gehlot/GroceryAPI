using Grocery.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortFilterController : ControllerBase
    {
        private readonly IProductService _productService;

        public SortFilterController(IProductService productService) {

            _productService = productService;
        }


        [HttpGet]
        [Route("GetProductByBrand")]
        public IActionResult GetProductsOfBrand(int id)
        {
            try
            {
                var products = _productService.GetProductOfBrand(id);
                return Ok(products);
            } catch (Exception) {
                return BadRequest("Wrong brand id ,brand id does not exist");

            }

        }

        [HttpGet]
        [Route("GetProductByCategory")]
        public IActionResult GetProductOfCategory(int id)
        {
            try
            {
                var products = _productService.GetProductOfCategory(id);
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest("Wrong Category id ,category id does not exist");

            }
        }


    }
}
