using AutoMapper;
using Grocery.common.Entities;
using Grocery.common.Model;
using Grocery.DAL.Interfaces;
using Grocery.services.Interfaces;

namespace Grocery.services.Classes
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userDataAccess, IMapper mapper)
        {
            _userRepository = userDataAccess;
            _mapper = mapper;
        }

        public void AddNewUser(UserModel userModel)
        {
            var userEntity = _mapper.Map<UserEntity>(userModel);
            _userRepository.AddNewUser(userEntity);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public UserModel GetUserById(int id)
        {
            var userEntity = _userRepository.GetUserById(id);
            if (userEntity == null)
            {
                throw new ArgumentException("User not found");
            }
            return _mapper.Map<UserModel>(userEntity);
        }

        public void UpdateUser(int id, UserModel userModel)
        {
            var existingUser = _userRepository.GetUserById(id);
            if (existingUser == null)
            {
                throw new ArgumentException("User not found");
            }
            _mapper.Map(userModel, existingUser);
            _userRepository.UpdateUser(existingUser);
        }
    }
}
