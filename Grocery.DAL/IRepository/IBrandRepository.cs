using Grocery.common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Interfaces
{
    public interface IBrandRepository
    {
        List<BrandEntity> GetAllBrandsFromDb();
        void AddNewBrandToDb(BrandEntity brandEntity);
        void DeleteBrandFromDb(int id);
        BrandEntity GetBrandById(int id);
        void UpdateBrandInDb(BrandEntity brandEntity); 
        bool IsExistById(int categoryId);
        bool IsExistByName(string name);
        string GetBrandName(int categoryId);
    }
}
