//using iTextSharp.text.pdf.qrcode;
//using iTextSharp.text.pdf.qrcode;
using HotelDAL;
using HotelDAL.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public class QRCodeService:IQRCodeService
    {
        public IQRCodeRepository QRCodeRepository;
        public QRCodeService(IQRCodeRepository QRCodeRepository)
        {
            this.QRCodeRepository = QRCodeRepository;
        }

        //check if customer has permission after scanning QR code
        public bool CheckPermissionToRoom(int roomNumber, string QRCodeValue)
        {
            return QRCodeRepository.GetQRCodeForRoom(roomNumber) == QRCodeValue; 
        }


        //get active QR codes for customer 
        public List<string> GetQRCodesValuesFotCustomer(int customerId)
        {
            return QRCodeRepository.GetActiveQRCodesFotCustomer(customerId);
        }


    }
}

