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
        public EmailAddress EmailAddress { get; }
        public Gender Gender { get; }
        public bool IsDeleted { get; private set; } = false;
        public FirstName FirstName
        {
            get => UserName.FirstName;
        }
        public LastName LastName
        {
            get => UserName.LastName;
        }

        public User(
            UserId userId,
            UserName userName,
            EmailAddress emailAddress,
            Gender gender,
            bool isDeleted)
        {
            Id = userId;
            UserName = userName;
            Gender = gender;
            EmailAddress = emailAddress;
            IsDeleted = isDeleted;
        }


        public static User CreateNewUser(
            FirstName firstName,
            LastName lastName,
            EmailAddress emailAddress,
            Gender gender)
        {
            return new User(
                UserId.Generate(),
                new UserName(firstName, lastName),
                emailAddress,
                gender, false);
        }

        public void ChangeUserName(UserName userName)
        {
            this.UserName = userName?? 
                throw new ArgumentNullException("ユーザ名は必須入力項目です。");
        }

        public void ChangeUserName(FirstName firstName, LastName lastName)
        {
            if(firstName is null)
                throw new ArgumentNullException($"必須入力項目です。{typeof(FirstName)}");
            if(lastName is null) 
                throw new ArgumentNullException($"必須入力項目です。{typeof(LastName)}");
            this.UserName = new UserName(firstName, lastName);
        }

        public void Delete()
        { 
            this.IsDeleted = true;
        }
    }
}
