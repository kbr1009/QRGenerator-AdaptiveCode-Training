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
            // 例外処理はここでする
            try
            {
                // ユーザ
                User user = User.CreateNewUser(
                    firstName: new FirstName(createUserModel.FirstName),
                    lastName: new LastName(createUserModel.LastName),
                    emailAddress: new EmailAddress(createUserModel.EmailAddress),
                    gender: (Gender)createUserModel.Gender);

                // ユーザ作成時のQRコード生成
                QRCode qRCode = QRCode.CreateQRCodeData(user);
                _qRCodeCreatecommand.Execute(qRCode);
                _repository.Save(user);
            }
            catch
            {
                throw;
            }
        }
    }
}
