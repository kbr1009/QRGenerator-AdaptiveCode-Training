using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;
using System.Drawing;


namespace QRGenerator
{
    public class QRGenerateService : IQRGenerateService
    {
        private readonly BarcodeWriter _barcodeWriter;
        private readonly int _width = 150;
        private readonly int _height = 150;
        private readonly int _margin = 3;
        private const string OUTPUT_FOLDER_PATH = @"C:\Users\81804\Pictures";
        private string _outputFilePath;
        public string OutPutFilePath
        {
            get =>  this._outputFilePath ?? throw new ArgumentNullException("QRコードが生成されていません。");
            private set => this._outputFilePath = value;
        }
        public QRGenerateService()
        {
            _barcodeWriter = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    ErrorCorrection = ErrorCorrectionLevel.M,
                    CharacterSet = "UTF-8",
                    Width = _width,
                    Height = _height,
                    Margin = _margin,
                },
            };
        }

        public QRGenerateService(int width, int height, int margin)
        {
            _barcodeWriter = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    ErrorCorrection = ErrorCorrectionLevel.M,
                    CharacterSet = "UTF-8",
                    Width = width,
                    Height = height,
                    Margin = margin,
                },
            };
        }

        public QRGenerateService(BarcodeWriter barcodeWriter)
        {
            this._barcodeWriter = barcodeWriter;
        }

        public void OnInitializing()
        {
            this._barcodeWriter.Format = BarcodeFormat.QR_CODE;
            this._barcodeWriter.Options = new QrCodeEncodingOptions
            {
                ErrorCorrection = ErrorCorrectionLevel.M,
                CharacterSet = "UTF-8",
            };
        }

        public void Generate(string qrCodeName, string strData)
        {
            this.OutPutFilePath = Path.Combine(OUTPUT_FOLDER_PATH, $"{qrCodeName}.png");

            using (var bitmap = this._barcodeWriter.Write(strData))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font font = new Font("ＭＳ ゴシック", 20, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString(qrCodeName, font, brush, new Point(80, 270));
                    bitmap.Save(this.OutPutFilePath, ImageFormat.Png);
                }
            }
        }

        //public void Generate(User user)
        //{
        //    var userName = user.UserName.Value;
        //    this.OutPutFilePath = Path.Combine(OUTPUT_FOLDER_PATH, $"{userName}.png");

        //    using (var bitmap = this._barcodeWriter.Write(user.Id.Value))
        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        using (Font font = new Font("ＭＳ ゴシック", 10, FontStyle.Bold))
        //        using (Brush brush = new SolidBrush(Color.Black))
        //        {
        //            if (user.UserName.Length == 5)
        //            {
        //                graphics.DrawString(userName, font, brush, new Point(45, 135));
        //            }
        //            else if (user.UserName.Length == 6)
        //            {
        //                graphics.DrawString(userName, font, brush, new Point(35, 135));
        //            }
        //            else if (user.UserName.Length == 7)
        //            {
        //                graphics.DrawString(userName, font, brush, new Point(25, 135));
        //            }
        //            else if (user.UserName.Length < 5)
        //            {
        //                graphics.DrawString(userName, font, brush, new Point(85, 135));
        //            }
        //            else if (user.UserName.Length > 7)
        //            {
        //                graphics.DrawString(userName, font, brush, new Point(85, 135));
        //            }
        //            else
        //            {
        //                throw new ArgumentException("名前の文字数が不正なためQRコードに名前が記載できません。");
        //            }

        //            bitmap.Save(this.OutPutFilePath, ImageFormat.Png);
        //        }
        //    }
        //}
    }
}
