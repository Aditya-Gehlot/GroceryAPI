using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Grocery.DAL.Interfaces;
using Grocery.common.Model;
using Grocery.services.Interfaces;
using AutoMapper;

namespace Grocery.services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;
        private readonly ILoginRepositroy _loginRepository;
        private readonly IMapper _mapper;

        public LoginService(IConfiguration configuration, ILoginRepositroy loginRepository, IMapper mapper)
        {
            _config = configuration;
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public UserModel AuthenticationUser(UserModel userModel)
        {
            var userEntity = _loginRepository.GetUser(userModel.Username);
            if (userEntity != null && userEntity.Password == userModel.Password)
            {
                return _mapper.Map<UserModel>(userEntity);
            }
            return null;
        }

        public string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
