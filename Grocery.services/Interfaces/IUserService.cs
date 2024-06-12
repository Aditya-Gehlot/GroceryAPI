using Grocery.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.services.Interfaces
{
    public interface IUserService
    {
        void AddNewUser(UserModel userModel);
        void DeleteUser(int id);
        UserModel GetUserById(int id);
        void UpdateUser(int id, UserModel userModel);
    }
}
