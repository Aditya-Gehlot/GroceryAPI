using Grocery.common.Model;
using Grocery.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.services.Interfaces
{
    public interface IStockService
    {
        List<ShowStockModel> GetAllStocks();
        void AddNewStock(StockModel stockModel);
        void DeleteStock(int id);
        void UpdateStock(StockModelUpdate stockModelUpdate);
        StockModel GetStockById(int id);
    }
}
