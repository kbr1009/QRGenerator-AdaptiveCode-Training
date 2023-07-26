using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;
using Domain.Services.QRCodes;

namespace Infrastructure.QRGenerator
{
    public class QRGenerate : IQRGenerate
    {
        private readonly BarcodeWriter _barcodeWriter;

        private readonly int _width = 150;
        private readonly int _height = 150;
        private readonly int _margin = 3;
        private const string OUTPUT_FOLDER_PATH = @"C:\Users\81804\Pictures";

        private string _outputFilePath;
        public string OutPutFilePath
        {
            get => this._outputFilePath ??
                throw new ArgumentNullException("QRコードが生成されていません。");
            private set => this._outputFilePath = value;
        }
        public QRGenerate()
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

        public QRGenerate(int width, int height, int margin)
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

        public void Generate(string qrCodeName, string qrCodeData)
        {
            this.OutPutFilePath = Path.Combine(OUTPUT_FOLDER_PATH, $"{qrCodeName}.png");

            Console.WriteLine($"Succeeded!!!: {this.OutPutFilePath} のQRコードを発行した");
            //using (var bitmap = this._barcodeWriter.Write(QrCodeData))
            //using (Graphics graphics = Graphics.FromImage(bitmap))
            //{
            //    using (Font font = new Font("ＭＳ ゴシック", 20, FontStyle.Bold))
            //    using (Brush brush = new SolidBrush(Color.Black))
            //    {
            //        if (qrCodeName.Length == 5)
            //        {
            //            graphics.DrawString(qrCodeName, font, brush, new Point(45, 135));
            //        }
            //        else if (qrCodeName.Length == 6)
            //        {
            //            graphics.DrawString(qrCodeName, font, brush, new Point(35, 135));
            //        }
            //        else if (qrCodeName.Length == 7)
            //        {
            //            graphics.DrawString(qrCodeName, font, brush, new Point(25, 135));
            //        }
            //        else if (qrCodeName.Length < 5)
            //        {
            //            graphics.DrawString(qrCodeName, font, brush, new Point(85, 135));
            //        }
            //        else if (qrCodeName.Length > 7)
            //        {
            //            graphics.DrawString(qrCodeName, font, brush, new Point(85, 135));
            //        }
            //        else
            //        {
            //            throw new ArgumentException("名前の文字数が不正なためQRコードに名前が記載できません。");
            //        }

            //        bitmap.Save(this.OutPutFilePath, ImageFormat.Png);
            //    }
        }

        //public void Generate(string qrCodeName, string QrCodeData)
        //{
        //    this.OutPutFilePath = Path.Combine(OUTPUT_FOLDER_PATH, $"{qrCodeName}.png");

        //    using (var bitmap = this._barcodeWriter.Write(QrCodeData))
        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        using (Font font = new Font("ＭＳ ゴシック", 20, FontStyle.Bold))
        //        using (Brush brush = new SolidBrush(Color.Black))
        //        {
        //            if (qrCodeName.Length == 5)
        //            {
        //                graphics.DrawString(qrCodeName, font, brush, new Point(45, 135));
        //            }
        //            else if (qrCodeName.Length == 6)
        //            {
        //                graphics.DrawString(qrCodeName, font, brush, new Point(35, 135));
        //            }
        //            else if (qrCodeName.Length == 7)
        //            {
        //                graphics.DrawString(qrCodeName, font, brush, new Point(25, 135));
        //            }
        //            else if (qrCodeName.Length < 5)
        //            {
        //                graphics.DrawString(qrCodeName, font, brush, new Point(85, 135));
        //            }
        //            else if (qrCodeName.Length > 7)
        //            {
        //                graphics.DrawString(qrCodeName, font, brush, new Point(85, 135));
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
