using HotelBL;
using HotelDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer.Controllers
{
    public class ChatController : BaseController
    {
        public IChatService chatService;
        public ChatController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        //add guest message
        [HttpPost("AddGuestMsg/{customerId}")]
        public Task<List<Message>> AddGuestMsg(string customerId, string msg)
        {
            return chatService.AddGuestMsg(customerId, msg);
        }

        //add service message
        [HttpPost("AddServiceMsg/{customerId}")]
        public Task<List<Message>> AddServiceMsg(string customerId, string msg)
        {
            return chatService.AddServiceMsg(customerId, msg);
        }

        //clear guest chat
        [HttpGet("Clear/{customerId}")]
        public List<Message> Clear(string customerId)
        {
            return chatService.Clear(customerId);
        }

        //rlload chat to guest every
        [HttpGet("ReloadChat/{customerId}")]
        public List<Message> ReloadChat(string customerId)
        {
            return chatService.ReloadChat(customerId);
        }

    }
}
