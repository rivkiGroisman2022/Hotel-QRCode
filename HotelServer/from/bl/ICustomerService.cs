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
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        bool PostCustomer(Customer entity);
        Customer PutCustomer(int id, Customer entity);
        bool DeleteCustomer(int id);
        Customer Login(string customerId, int orderNum);

        List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum);
    }
}
