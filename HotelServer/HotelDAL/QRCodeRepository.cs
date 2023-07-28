using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL
{
    public class QRCodeRepository : IQRCodeRepository
    {
        public readonly HotelContext context;
        public QRCodeRepository(HotelContext context)
        {
            this.context = context;
        }

        public bool CheckAccessForRoom(int roomNum, string scanValue)
        {
            try
            {
                var room = context.RoomToGuests.Where(x => x.RoomNumber == roomNum && x.Order.EntryDate <= DateTime.Now && x.Order.DepartureDate > DateTime.Now).FirstOrDefault();
                if (room != null && room.Qr == scanValue)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("CheckAccessForRoom", ex.Message);
                return false;
            }
        }

        public List<string> GetActiveQRCodesFotCustomer(int roomNum)
        {
            throw new NotImplementedException();
        }

        public string GetQRCodeForRoom(int roomNum)
        {
            try
            {
                RoomToGuest roomToGuests = context.RoomToGuests.Where(x => x.RoomNumber == roomNum && x.Order.EntryDate <= DateTime.Now && x.Order.DepartureDate > DateTime.Now).FirstOrDefault();
                if (roomToGuests != null)
                {
                    return roomToGuests.Qr;
                }
                else return "";

            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("GetQRCodeForRoom", ex.Message);
                return "";
            }
        }


    }
}
