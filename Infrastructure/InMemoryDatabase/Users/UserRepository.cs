using Domain.Models.Users;
using Domain.Services.Users;
using Domain.Models.Users.UserNames;
using Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Infrastructure.InMemoryDatabase.Users
{
    public class UserRepository : IUserRepository
    {
        AppContext _context;
        public UserRepository(AppContext appContext) 
        { 
            this._context = appContext;
        }
        public void Save(User user)
        {
            _context.Users.Add(ToDataModel(user));
        }

        public User Find(EmailAddress emailAddress)
        {
            USER userDataModel = _context.Users
                .FirstOrDefault(x => x.EmailAddress == emailAddress.Value);
            if (userDataModel is null) return null;
            return ToModel(userDataModel);
        }
        private USER ToDataModel(User user) 
        {
            return new USER
            {
                Id = user.Id.Value,
                UserName = user.UserName.Value,
                EmailAddress = user.EmailAddress.Value,
                Gender = (int)user.Gender,
                IsDeleted = user.IsDeleted
            };
        }

        private User ToModel(USER from)
        {
            return new User(
                new UserId(from.Id), 
                new UserName(from.UserName), 
                new EmailAddress(from.EmailAddress), 
                (Gender)from.Gender, 
                from.IsDeleted);
        }

        private IEnumerable<User> ToModels(IEnumerable<USER> from) 
        {
            foreach (var i in from)
            {
                yield return ToModel(i);
            }
        }
    }
}
