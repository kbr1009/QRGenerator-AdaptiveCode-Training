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
//IQRGenerate qRGenerater = provider.GetService<IQRGenerate>();
//IQRCodeCreateCommand qrCodeCreate = new QRCodeCreateCommand(qRGenerater);
////-ユーザ情報・QRコードの作成テストコード
//User user = User.CreateNewUser(new FirstName("怜雄"), new LastName("小林"), (Gender)0);
//QRCode qRCode = new QRCode(user);
//qrCodeCreate.Execute(qRCode);

// ユーザを新たに生成するテスト
IUserCreateCommand createUerCmd = provider.GetService<IUserCreateCommand>();
CreateUserModel createUserModel = new CreateUserModel();
createUserModel.FirstName = "怜雄";
createUserModel.LastName = "小林";
createUserModel.EmailAddress = "reo109r@icloud.com";
createUserModel.Gender = (int)Gender.男性;
createUerCmd.Execute(createUserModel);

EmailAddress emailAddress = new EmailAddress("reo109r@icloud.com");
Console.WriteLine($"E-mail:{emailAddress.Value}");
Console.WriteLine($"プリンシパル名：{emailAddress.GetPrincipal()}");
Console.WriteLine($"ドメイン名：{emailAddress.GetDomain()}");

EmailAddress emailAddressByForm = EmailAddress.FromPartsCreate("reo","google.com");
Console.WriteLine($"E-mail:{emailAddressByForm.Value}");
Console.WriteLine($"プリンシパル名：{emailAddressByForm.GetPrincipal()}");
Console.WriteLine($"ドメイン名：{emailAddressByForm.GetDomain()}");

// Emailアドレスのバリューオブジェクト参考
// https://github.com/draphyz/DDD/blob/entityframework/Src/DDD.Common/Domain/EmailAddress.cs
// 区分をオブジェクトで実装する
// https://qiita.com/haguta/items/ceca207c313eef332cb1
// CQRS参考
// https://github.com/0mmadawn/DDD_CQRS_Sample/blob/main/LibraryApplication/Commands/Handlers/RegisterUserHandler.cs
