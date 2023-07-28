using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Users
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsDupulicatedUser(User user)
        {
            var duplicatedUser = _userRepository.Find(user.EmailAddress);

            return duplicatedUser != null;
        }
    }
}
