using AutoMapper;
using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.DAL.Classes;
using Grocery.DAL.Interfaces;
using Grocery.services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Grocery.services.Classes
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public List<BrandModelUpdate> GetAllBrands()
        {
            var brands = _brandRepository.GetAllBrandsFromDb();
            return _mapper.Map<List<BrandModelUpdate>>(brands);
        }

        public void AddNewBrand(BrandModel brandModel)
        {
            var brandexist = _brandRepository.IsExistByName(brandModel.brand_name);
            if (brandexist)
            {
                throw new Exception("Brand Already Exist");
            }
            var brandEntity = _mapper.Map<BrandEntity>(brandModel);
            _brandRepository.AddNewBrandToDb(brandEntity);
        }

        public void DeleteBrand(int id)
        {
            _brandRepository.DeleteBrandFromDb(id);
        }

        public void UpdateBrand(BrandModelUpdate brandModelUpdate)
        {
            var brandentity=_mapper.Map<BrandEntity>(brandModelUpdate);
            //var brand = _dbContext.BrandTable.Find(brandEntity.brand_id);
            var brand= _brandRepository.IsExistById(brandentity.brand_id);
            if (!brand)
            {
                throw new ArgumentException("Brand not found");
            }
            _brandRepository.UpdateBrandInDb(brandentity);
        }

        public BrandModel GetBrandById(int id)
        {
            var brandEntity = _brandRepository.GetBrandById(id);
            if (brandEntity == null)
            {
                throw new ArgumentException("Brand not found");
            }

            return _mapper.Map<BrandModel>(brandEntity);
        }
    }
}