using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Classes
{
    public class LoginRepository:ILoginRepositroy
    {
        private readonly ApplicationDbContext dbContext;

        public LoginRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserEntity GetUser(string username)
        {
            return dbContext.UserTable.FirstOrDefault(u => u.Username == username);
        }
    }
}
