using HotelBL;
using HotelDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer.Controllers
{
    public class CustomerController : BaseController
    {
        public ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        //login 
        [HttpGet("Login/{id}/{orderNum}")]
        public Customer Login(string id, string orderNum)
        {
            return customerService.Login(id, int.Parse(orderNum));
        }

        //get customer availabilities for rooms
        [HttpGet("GetCustomerAvailabilities/{customerId}")]
        public List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum)
        {
            return customerService.GetCustomerAvailability(customerId, orderNum);
        }

        //get QRCodes to user
        [HttpGet("GetQRCodes/{customerId}")]
        public List<RoomToGuest> GetQRCodes(string customerId, int orderNum)
        {
            return customerService.GetQRCodes(customerId, orderNum);
        }

        //Update Aailability
        [HttpPost("UpdateAailability/{customerId}/{orderNum}/{roomNumber}")]
        public List<RoomToGuest> UpdateAailability(string customerId, int orderNum, int roomNumber, string status)
        {
            return customerService.UpdateAailability(customerId, orderNum, roomNumber, status);
        }

        //Update Favorite Room
        [HttpPost("UpdateFavoriteRoom/{customerId}/{orderNum}/{roomNumber}")]
        public List<RoomToGuest> UpdateFavoriteRoom(string customerId, int orderNum, int roomNumber, bool favorite)
        {
            return customerService.UpdateFavoriteRoom(customerId, orderNum, roomNumber, favorite);
        }

    }
}
