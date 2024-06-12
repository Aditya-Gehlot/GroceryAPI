using Grocery.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.services.Interfaces
{
    public interface IBrandService
    {
        List<BrandModelUpdate> GetAllBrands();
        void AddNewBrand(BrandModel brandModel);
        public void DeleteBrand(int id);
        void UpdateBrand(BrandModelUpdate brandModelUpdate);
        BrandModel GetBrandById(int id);
    }
}
