using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public interface ICustomerService
    {
        Customer Login(string customerId, int orederId);
        List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum);
        List<RoomToGuest> GetQRCodes(string customerId, int orderNum);
        List<RoomToGuest> UpdateAailability(string customerId, int orderNum, int roomNumber, string status);
        List<RoomToGuest> UpdateFavoriteRoom(string customerId, int orderNum, int roomNumber, bool favorite);
    }
}
