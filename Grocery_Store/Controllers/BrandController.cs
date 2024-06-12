using Grocery.common.Model;
using Grocery.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
            var brands = _brandService.GetAllBrands();
            return Ok(brands);
        }

        [Authorize]
        [HttpPost]
        [Route("AddNewBrand")]
        public IActionResult AddNewBrand(BrandModel brandModel)
        {
            try
            {

            _brandService.AddNewBrand(brandModel);
            return Ok("Brand Added Successfully");
            }catch (Exception)
            {
                return BadRequest("Brand Already Exist.");
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("deletebrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                _brandService.DeleteBrand(id);
            return Ok("Brand Deleted Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(500,"Brand with this id does not found.");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Update Brand")]
        public IActionResult UpdateBrand(BrandModelUpdate brandModelUpdate)
        {
            try
            {
                _brandService.UpdateBrand(brandModelUpdate);
            return Ok("Brand Updated Succefully");
            }
            catch (Exception)
            {
                return StatusCode(500,"the id you entered is not found");
            }
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetBrandById(int id)
        {
            try
            {
                var brand = _brandService.GetBrandById(id);
                return Ok(brand);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(500,"Entered id does not exist in this context");
            }
            
        }
    }
}
