﻿using System;
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
                    firstName: new FirstName(createUserModel.FirstName),
                    lastName: new LastName(createUserModel.LastName),
                    gender: (Gender)createUserModel.Gender);

                QRCode qRCode = QRCode.QRCodeDataCreate(user);
                _qRCodeCreatecommand.Execute(qRCode);
                _repository.Create(user);
            }
            catch
            {
                throw;
            }
        }
    }
}