using HotelBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer.Controllers
{
    public class QRCodeController : BaseController
    {
        private readonly IQRCode QRCode;
        public QRCodeController(IQRCode QRCode)
        {
            this.QRCode = QRCode;
        }
        [HttpGet("Check")]
        public bool Check()
        {
           return QRCode.QRCompare();
        }
    }
}
