using Domain.Models.Users;
using Domain.Services.QRCodes;
using Infrastructure.QRGenerator;
using Microsoft.Extensions.DependencyInjection;
using Domain.Models.Users.UserNames;
using Domain.Models.QRCodes;
using Application.QRCodes.Commands;
using Domain.Services.Users;
using Infrastructure.InMemoryDatabase.Users;
using Application.Users.Commands;

// ♡ラブ注入♡ ＊DI
ServiceCollection services = new ServiceCollection();
services.AddTransient<IQRGenerate, QRGenerate>();
services.AddTransient<IUserRepository, UserRepository>();
services.AddTransient<IQRCodeCreateCommand, QRCodeCreateCommand>();
services.AddTransient<IUserCreateCommand, UserCreateCommand>();
using var provider = services.BuildServiceProvider();

// 機能ごとにテストがかけるの最高杉
// 部品の組み立て
IQRGenerate qRGenerater = provider.GetService<IQRGenerate>();
IQRCodeCreateCommand qrCodeCreate = new QRCodeCreateCommand(qRGenerater);
//-ユーザ情報・QRコードの作成テストコード
User user = User.CreateNewUser(new FirstName("怜雄"), new LastName("小林"), Gender.男性);
QRCode qRCode = new QRCode(user);
qrCodeCreate.Execute(qRCode);

// ユーザを新たに生成するテスト
IUserCreateCommand createUerCmd = provider.GetService<IUserCreateCommand>();
CreateUserModel createUserModel = new CreateUserModel();
createUserModel.FirstName = "怜雄";
createUserModel.LastName = "小林";
createUserModel.Gender = (int)Gender.男性;
createUerCmd.Execute(createUserModel);
