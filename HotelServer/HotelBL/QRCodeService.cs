//using iTextSharp.text.pdf.qrcode;
//using iTextSharp.text.pdf.qrcode;
using HotelDAL;
using HotelDAL.Models;
using HotelServer;
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
        private readonly HotelServer.EmailManager _emailManager;

        public QRCodeService(IQRCodeRepository QRCodeRepository, HotelServer.EmailManager emailManager)
        {
            this.QRCodeRepository = QRCodeRepository;
            _emailManager = emailManager;
        }

        public bool SendQRCode(string toMail, int roomNumber)
        {
            try
            {
                string QRvalue = QRCodeRepository.GetQRCodeForRoom(roomNumber);
                if (QRvalue != "")
                {
                    _emailManager.SendEmail(toMail, roomNumber, QRvalue);
                    return true;
                }
                else return false;
                
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            
        }

        public bool CheckAccessForRoom(int roomNum, string scanValue)
        {
            return QRCodeRepository.CheckAccessForRoom(roomNum, scanValue);
        }

    }
}

