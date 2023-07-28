using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Domain.Services.Users
{
    public interface IUserRepository
    {
        void Save(User user);
        User Find(EmailAddress emailAddress);
    }
}
