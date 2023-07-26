using Domain.Models.QRCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QRCodes.Commands
{
    public interface IQRCodeCreateCommand
    {
        void Execute(QRCode qRCode);
    }
}
