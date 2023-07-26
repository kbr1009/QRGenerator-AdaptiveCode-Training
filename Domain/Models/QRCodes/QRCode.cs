using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;


namespace Domain.Models.QRCodes
{
    public class QRCode
    {
        public User User { get; }
        public string QRCodeImageName 
        {
            get => this.User.UserName.Value;
        }

        public string QRCodeImageFileName
        {
            get => $"{this.User.UserName.Value}.png";
        }

        public string QRCodeValue
        {
            get => this.User.Id.Value;
        }

        public QRCode(User user)
        { 
            this.User = user ?? 
                throw new ArgumentNullException("error!: ユーザ情報がないとQRコードが作成できません。");
        }

        public static QRCode CreateQRCodeData(User user)
        {
            return new QRCode(user);
        }
    }
}
