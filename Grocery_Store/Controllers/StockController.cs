using AutoMapper;
using Grocery.common.Model;
using Grocery.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grocery_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService,IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet]
        [Route("GetAllStocks")]
        public IActionResult GetAllStocks()
        {
            var stocks = _stockService.GetAllStocks();
            return Ok(stocks);   
        }


        [Authorize]
        [HttpPost]
        [Route("AddNewStock")]
        public IActionResult AddNewStock(StockModel stockModel)
        {
            try
            {
                _stockService.AddNewStock(stockModel);
                return Ok("Stock Added Succesfully");
            }catch (Exception) {
                return StatusCode(500, "Product id does not exist");
            }
       
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            try
            {
                _stockService.DeleteStock(id);
                return Ok("Stock Deleted Succesfully");
            }catch (Exception) {
                return StatusCode(500, "Entered id does not exist.");
            }
           
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateStock(StockModelUpdate stockModelUpdate)
        {
            try
            {
                _stockService.UpdateStock(stockModelUpdate);
            return Ok("Stock Updated Succesfully");
            }
            catch (ArgumentException)
            {
                return StatusCode(500, "wrong stock id");
            }
            catch(Exception)
            {
                return StatusCode(500, "wrong product id");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetStockById(int id)
        {
            try
            {
                var stock = _stockService.GetStockById(id);
                return Ok(stock);
            }
            
            catch (Exception)
            {
                return StatusCode(500, "wrong id");
            }
        }
    }
}
