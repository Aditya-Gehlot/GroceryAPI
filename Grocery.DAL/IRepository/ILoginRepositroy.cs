using Grocery.common.Entities;
using Grocery.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Interfaces
{
    public interface ILoginRepositroy
    {
        UserEntity GetUser(string username);
    }
}
