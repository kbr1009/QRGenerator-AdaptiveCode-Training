using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Users;
using Domain.Models.Users;

namespace Infrastructure.InMemoryDatabase.Users
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user) 
            => Console.WriteLine($"ID: {user.Id.Value} - {user.UserName.Value}を生成しました。");
    }
}
