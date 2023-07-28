using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public interface IQRCodeService
    {
        bool SendQRCode(string toEmail, int roomNumber);
        bool CheckAccessForRoom(int roomNum, string scanValue);
    }
}
