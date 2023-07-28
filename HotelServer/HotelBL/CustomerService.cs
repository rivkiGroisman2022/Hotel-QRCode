using HotelDAL;
using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<RoomToGuest> UpdateAailability(string customerId, int orderNum, int roomNumber, string status)
        {
            return this.customerRepository.UpdateAailability(customerId, orderNum, roomNumber, status);
        }

        public List<RoomToGuest> UpdateFavoriteRoom(string customerId, int orderNum, int roomNumber, bool favorite)
        {
            return this.customerRepository.UpdateFavoriteRoom(customerId, orderNum, roomNumber, favorite);
        }

        public List<RoomToGuest> GetQRCodes(string customerId, int orderNum)
        {
            var list = customerRepository.GetQRCodes(customerId, orderNum);
            var orderedList = list.OrderByDescending(x => x.Favorite).ToList();
            return orderedList;
        }

        public Customer Login(string customerId, int orederId)
        {
            return customerRepository.Login(customerId, orederId);
        }



        public List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum)
        {
            throw new NotImplementedException();
        }
    }
}
