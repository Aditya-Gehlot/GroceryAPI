using AutoMapper;
using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.Common.Model;
using Grocery.DAL.Interfaces;
using Grocery.services.Interfaces;
namespace Grocery.services.Classes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStockRepository _stockRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper, IBrandRepository brandRepository, ICategoryRepository categoryRepository, IStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _stockRepository = stockRepository;
        }

        public List<ShowProductModel> GetAllProducts()
        {
            var products = _productRepository.GetAllProductsFromDb();
            return _mapper.Map<List<ShowProductModel>>(products);
        }

        public void AddNewProduct(ProductModel productModel)
        {
            var productexist = _productRepository.IsProductExist(productModel.product_name);
            if (productexist) {
                throw new Exception("Product Already Exist");
            }
            var productEntity = _mapper.Map<ProductEntity>(productModel);
            CheckValidation(productEntity);
            int currentId = _productRepository.GetProductId() + 1;
            var stock = new StockEntity
            {
                product_id = currentId,
                product_name = productEntity.product_name,
                produt_quantity = productEntity.produt_quantity,
                product_price=productModel.product_price,
                CreatedAtDate=productModel.CreatedAtDate
            };

            var brandname = _brandRepository.GetBrandName(productModel.brand_id);
            var categoryname = _categoryRepository.GetCategoryName(productModel.category_id);
            productEntity.brand_name = brandname;
            productEntity.category_name = categoryname;
            _productRepository.AddNewProductToDb(productEntity, stock);
        }

        public void UpdateProduct(ProductModelUpdate productModelUpdate)
        {
            var productEntity = _mapper.Map<ProductEntity>(productModelUpdate);
            CheckValidation(productEntity);
            var stock = _stockRepository.GetStockByProductId(productEntity.product_id);
            if (stock != null)
            {
                stock.product_id = productEntity.product_id;
                stock.produt_quantity += productEntity.produt_quantity;
                stock.product_name = productEntity.product_name;
            }
            _productRepository.UpdateProductInDb(productEntity, stock);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProductFromDb(id);
        }

        public ProductModel GetProductById(int id)
        {
            var productEntity = _productRepository.GetProductById(id);
            if (productEntity == null)
            {
                throw new ArgumentException("Brand not found");
            }
            return _mapper.Map<ProductModel>(productEntity);
        }
        private void CheckValidation(ProductEntity productModel)
        {
            if (!_brandRepository.IsExistById(productModel.brand_id))
                throw new ArgumentException("Wrong Brand id.");
            if (!_categoryRepository.IsExistById(productModel.category_id))
                throw new AggregateException("Wrong Category id.");
        }

        public List<ShowProductModel> GetProductOfBrand(int id)
        {
            var products = _productRepository.GetProductOfBrand(id);
            if(products == null || products.Count==0)
            {
                throw new Exception("Brand Id does not exist");
            }
            return _mapper.Map<List<ShowProductModel>>(products);
        }
        public List<ShowProductModel> GetProductOfCategory(int id)
        {
            var products = _productRepository.GetProductOfCategory(id);
            if (products == null || products.Count == 0)
            {
                throw new Exception("Category Id does not exist");
            }
            return _mapper.Map<List<ShowProductModel>>(products);
        }

    }
}
