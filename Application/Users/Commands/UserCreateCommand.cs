using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Users;
using Domain.Models.Users;
using Domain.Models.Users.UserNames;
using Application.QRCodes.Commands;
using Domain.Models.QRCodes;

namespace Application.Users.Commands
{
    public class UserCreateCommand : IUserCreateCommand
    {
        private readonly IUserRepository _repository;
        private readonly IQRCodeCreateCommand _qRCodeCreatecommand;
        public UserCreateCommand(
            IUserRepository userRepository, 
            IQRCodeCreateCommand qRCodeCreateCommand)
        {
            _repository = userRepository;
            _qRCodeCreatecommand = qRCodeCreateCommand;
        }  

        public void Execute(CreateUserModel createUserModel)
        {
            try
            {
                User user = User.CreateNewUser(
                    userName: new UserName(createUserModel.FirstName, createUserModel.LastName),
                    emailAddress: new EmailAddress(createUserModel.EmailAddress),
                    gender: (Gender)createUserModel.Gender);

                UserService userService = new UserService(_repository);
                if (userService.IsDupulicatedUser(user))
                {
                    throw new ArgumentException($"入力されたメールアドレスはすでに登録されています。");
                }

                QRCode qRCode = QRCode.CreateQRCodeData(user);

                _qRCodeCreatecommand.Execute(qRCode);
                _repository.Save(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
