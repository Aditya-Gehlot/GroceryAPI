using System;
using AutoMapper;
using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.Common.Model;

namespace Grocery.services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<BrandEntity, BrandModel>().ReverseMap();
            CreateMap<CategoryEntity, CategoryModel>().ReverseMap();
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            CreateMap<StockEntity, StockModel>().ReverseMap();
           CreateMap<BrandEntity, BrandModelUpdate>().ReverseMap();
            CreateMap<CategoryEntity, CategoryModelUpdate>().ReverseMap();
            CreateMap<ProductEntity, ProductModelUpdate>().ReverseMap();
            CreateMap<StockEntity, StockModelUpdate>().ReverseMap();
            CreateMap<ProductEntity, ShowProductModel>().ReverseMap();
            CreateMap<StockEntity, ShowStockModel>().ReverseMap();

        }
    }
}

