using Grocery.common.Entities;
using Grocery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Classes
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewUser(UserEntity userEntity)
        {
            _dbContext.UserTable.Add(userEntity);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.UserTable.Find(id);
            if (user != null)
            {
                _dbContext.UserTable.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public UserEntity GetUserById(int id)
        {
            return _dbContext.UserTable.FirstOrDefault(u => u.UserId == id);
        }

        public void UpdateUser(UserEntity userEntity)
        {
            _dbContext.UserTable.Update(userEntity);
            _dbContext.SaveChanges();
        }

    }
}
