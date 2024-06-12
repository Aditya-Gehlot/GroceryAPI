using Grocery.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.services.Interfaces
{
    public interface ILoginService
    {
        public UserModel AuthenticationUser(UserModel user);

        public string GenerateToken(UserModel users);

    }
}
