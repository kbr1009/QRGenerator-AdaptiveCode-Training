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
        public string FirstName
        {
            get => UserName.FirstName;
        }
        public string LastName
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
            UserName userName,
            EmailAddress emailAddress,
            Gender gender)
        {
            return new User(
                UserId.Generate(),
                userName,
                emailAddress,
                gender, false);
        }

        public void ChangeUserName(UserName userName)
        {
            this.UserName = userName?? 
                throw new ArgumentNullException("ユーザ名は必須入力項目です。");
        }

        public void ChangeUserName(string firstName, string lastName)
        {
            if(firstName is null)
                throw new ArgumentNullException($"名前は必須入力項目です。");

            if(lastName is null) 
                throw new ArgumentNullException($"苗字は必須入力項目です。");

            this.UserName = new UserName(firstName, lastName);
        }

        public void Delete()
        { 
            this.IsDeleted = true;
        }
    }
}
