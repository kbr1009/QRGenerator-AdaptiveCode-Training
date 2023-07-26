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
        void Generate(string qrCodeName, string strData);
    }
}
