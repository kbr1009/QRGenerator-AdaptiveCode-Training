using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.QRCodes;
using Domain.Services.QRCodes;

namespace Application.QRCodes.Commands
{
    public class QRCodeCreateCommand : IQRCodeCreateCommand
    {
        private readonly IQRGenerate _qRGenerate;
        public QRCodeCreateCommand(IQRGenerate qRGenerate)
        {
            _qRGenerate = qRGenerate ?? 
                throw new ArgumentNullException("error!: QRコードのインターフェースが設定されていない");
        }

        public void Execute(QRCode qRCode)
        {
            _qRGenerate.Generate(qRCode.QRCodeImageName, qRCode.QRCodeValue);
        }
    }
}
