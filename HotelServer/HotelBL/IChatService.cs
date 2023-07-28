using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public interface IChatService
    {
        Task<List<Message>> AddGuestMsg(string customerId, string message);
        Task<List<Message>> AddServiceMsg(string customerId, string message);
        List<Message> Clear(string customerId);
        List<Message> ReloadChat(string customerId);
    }

}
