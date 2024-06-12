using Grocery.common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Interfaces
{
    public interface IUserRepository
    {
        void AddNewUser(UserEntity userEntity);
        void DeleteUser(int id);
        UserEntity GetUserById(int id);
        void UpdateUser(UserEntity userEntity);
    }
}
