//using QRGenerator.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGenerator
{
    public interface IQRGenerateService
    {
        string OutPutFilePath { get; }
        void Generate(string qrCodeName, string strData);
        //void Generate(User user);
    }
}
