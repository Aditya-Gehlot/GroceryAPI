using AutoMapper;
using CT.Email.Service;
using Grocery.common.Model;
using Grocery.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMTPMailing.Services;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ProductController(IProductService productService, IMapper mapper,IEmailService emailService)
        {
            _productService = productService;
            _mapper = mapper;
            _emailService = emailService;
        }

     //[Authorize]
     //   [HttpGet]
     //   [Route("GetStoreName")]
     //   public string Details()
     //   {
     //       return "Grocery Store By Aditya";
     //   }    

    //    [Authorize]
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductModel product)
        {
            try
            {

                _productService.AddNewProduct(product);
                var emailTemplate = await System.IO.File.ReadAllTextAsync("C:\\Users\\admin\\source\\repos\\Grocery.common\\Template.html");
                var emailBody = emailTemplate.Replace("@(operation)", $"Product: {product.product_name}");
                var emailmodel = new EmailModel
                {
                    To = "ashudoorwar@gmail.com",
                    Subject = "Added Product",
                    Body = emailBody
                };
                await _emailService.SendEmailAsync(emailmodel);
                return Ok("Product Added Succesfully.");
            }
            catch (ArgumentException) {
                return StatusCode(500, "Brand ID wrong");
            }
            catch (AggregateException) {
                return StatusCode(500, "Category ID wrong");
            }

        }

       //[Authorize]
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occurred while retrieving the products.");
            }
        }

     //   [Authorize]
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(ProductModelUpdate productModelUpdate)
        {
            try
            {
                _productService.UpdateProduct(productModelUpdate);
                return Ok("Product Updated Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Entered ID does not exist.");
            }
        }

   //     [Authorize]
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok("Product Deleted Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Product with this id does not exist.");
            }
        }

    //    [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                return Ok(product);
            }
            catch (ArgumentException)
            {
                return NotFound("Entered ID does not exist in this context.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the product.");
            }
        }


    }
}
