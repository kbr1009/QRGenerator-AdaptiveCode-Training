using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.QRCodes;
using QRCoder;


namespace Infrastructure.QRGenerator
{
    public class QRGenerate : IQRGenerate
    {
        private readonly QRCodeGenerator _qRCodeGenerator;

        public QRGenerate()
        {
            _qRCodeGenerator = new QRCodeGenerator();
        }

        public void Generate(string qrCodeName, string qrCodeData)
        {
            QRCodeData qRCodeData = _qRCodeGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qRCodeData);
            byte[] bytes = qrCode.GetGraphic(10);
            string base64Str = Convert.ToBase64String(bytes);
            string imageSrc = string.Format("data:image/png;base64,{0}", base64Str);
            Console.WriteLine(imageSrc);
        }

        public void Generate()
        {
        }

        public void UploadQRCode() { }
    }
}
