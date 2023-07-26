using Domain.Models.Users.UserNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class User
    {
        public UserId Id { get; }
        public UserName UserName { get; private set; }
        public FirstName FirstName { get => UserName.FirstName; }
        public LastName LastName { get => UserName.LastName; }
        public Gender Gender { get; }
        public bool IsDeleted { get; private set; } = false;

        public User(UserId userId, UserName userName, Gender gender, bool isDeleted)
        {
            Id = userId;
            UserName = userName;
            Gender = gender;
            IsDeleted = isDeleted;
        }

        public static User CreateNewUser(FirstName firstName, LastName lastName, Gender gender)
        {
            UserName userName = new UserName(firstName, lastName);
            return new User(UserId.Generate(), userName, gender, false);
        }
    }
}
