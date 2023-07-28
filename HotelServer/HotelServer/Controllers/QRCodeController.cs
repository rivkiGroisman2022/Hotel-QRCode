using HotelBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer.Controllers
{
    public class QRCodeController : BaseController
    {
        private readonly IQRCodeService QRCodeService;
        public QRCodeController(IQRCodeService QRCodeService)
        {
            this.QRCodeService = QRCodeService;
        }


        //share QR code by email
        [HttpPost("ShareQRCode/{roomNumber}")]
        public bool ShareQRCode(int roomNumber, string toMail)
        {
            return QRCodeService.SendQRCode(toMail, roomNumber);
        }

        //chack permission to room
        [HttpPost("CheckAccessForRoom/{roomNumber}")]
        public bool CheckAccessForRoom(int roomNumber, string scanValue)
        {
            return QRCodeService.CheckAccessForRoom(roomNumber, scanValue);
        }


    }
}
