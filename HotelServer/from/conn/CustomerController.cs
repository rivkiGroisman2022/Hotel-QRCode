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
        [HttpPost("Login/{customerId}/{orderNum}")]
        public Customer Login(string customerId, int orderNum)
        {
            return customerService.Login(customerId, orderNum);
        }

        //get customer availabilities for rooms
        [HttpGet("GetCustomerAvailabilities/{customerId}")]
        public List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum)
        {
            return customerService.GetCustomerAvailability(customerId, orderNum);
        }

    }
}
