using AutoMapper;
using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.Common.Model;
using Grocery.DAL.Interfaces;
using Grocery.services.Interfaces;

namespace Grocery.services.Classes
{
    public class StockService:IStockService
    {

        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public StockService(IStockRepository stockRepository, IMapper mapper,IProductRepository productRepository)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
            _productRepository=productRepository;
        }

        public List<ShowStockModel> GetAllStocks()
        {
            var stocks = _stockRepository.GetAllStocksFromDb();
            return _mapper.Map<List<ShowStockModel>>(stocks);
        }

        public void AddNewStock(StockModel stockModel)
        {
            bool isStockExist = _productRepository.IsProductExist(stockModel.product_id);
            if (!isStockExist)
            {
                throw new Exception("Product not valid");
            }
            var stock=_stockRepository.GetStockById(stockModel.product_id);
            if (stock != null)
            {
                stock.produt_quantity += stockModel.produt_quantity;
                _stockRepository.UpdateStock(stock);
                var product = _productRepository.GetProductById(stockModel.product_id);
                if(product != null)
                {
                    product.produt_quantity += stockModel.produt_quantity;
                    _productRepository.UpdateProductFromStock(product);
                }
            }
            else
            {
                var stocks=_mapper.Map<StockEntity>(stockModel);
                _stockRepository.AddNewStockToDb(stocks);
            }


            if(stockModel != null) { 
            var stockEntity = _mapper.Map<StockEntity>(stockModel);
            _stockRepository.AddNewStockToDb(stockEntity);
            }
        }

      

        public void UpdateStock(StockModelUpdate stockModelUpdate)
        {
            var stock = _stockRepository.GetStockById(stockModelUpdate.stock_id);
            if (stock == null)
            {
                throw new ArgumentException("Stock not found");
            }
            bool product_id=_productRepository.IsProductExist(stockModelUpdate.product_id);
            if (!product_id) 
            {
                throw new Exception("Product id is wrong");
            }
            stock.product_id=stockModelUpdate.product_id;
            stock.produt_quantity+=stockModelUpdate.produt_quantity;
            var stocks = _mapper.Map<StockEntity>(stock);
            _stockRepository.UpdateStock(stock);
            var product = _productRepository.GetProductId(stockModelUpdate.product_id);
            if (product != null)
            {
                product.produt_quantity +=stockModelUpdate.produt_quantity;
                _productRepository.UpdateProductFromStock(product);
            }

        }
        public void DeleteStock(int id)
        {
            _stockRepository.DeleteStockFromDb(id);
        }
        public StockModel GetStockById(int id)
        {
            var stockEntity = _stockRepository.GetStockById(id);
            if (stockEntity == null)
            {
                throw new ArgumentException("Stock not found");
            }

            return _mapper.Map<StockModel>(stockEntity);
        }



    }
}
