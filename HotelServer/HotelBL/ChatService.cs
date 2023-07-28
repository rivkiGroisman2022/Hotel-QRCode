using HotelDAL;
using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public class ChatService : IChatService
    {
        public IChatRepository chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }
        public Task<List<Message>> AddGuestMsg(string customerId, string message)
        {
            return chatRepository.AddGuestMsg(customerId, message);
        }

        public Task<List<Message>> AddServiceMsg(string customerId, string message)
        {
            return chatRepository.AddServiceMsg(customerId, message);
        }

        public List<Message> Clear(string customerId)
        {
            return chatRepository.Clear(customerId);
        }

        public List<Message> ReloadChat(string customerId)
        {
            return chatRepository.ReloadChat(customerId);
        }
    }
}
