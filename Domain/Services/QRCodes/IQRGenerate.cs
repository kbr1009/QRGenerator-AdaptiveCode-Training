//using QRGenerator.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.QRCodes
{
    public interface IQRGenerate
    {
        string OutPutFilePath { get; }
        void Generate(string qrCodeName, string strData);
    }
}
