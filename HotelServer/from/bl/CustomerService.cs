using HotelDAL;
using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public class CustomerService // : ICustomerService
    {
        public ICustomerRepository customerRepository;
        //public CustomerService(ICustomerRepository customerRepository)
        //{
        //    this.customerRepository = customerRepository;
        //}
        //public bool DeleteCustomer(int id)
        //{
        //    return customerRepository.Delete(id);
        //}

        //public List<Customer> GetAllCustomers()
        //{
        //    return customerRepository.Get();
        //}

        //public Customer GetCustomerById(int id)
        //{
        //    return customerRepository.GetById(id);
        //}

        //public bool PostCustomer(Customer entity)
        //{
        //    return customerRepository.Post(entity);
        //}

        //public Customer PutCustomer(int id, Customer entity)
        //{
        //    return customerRepository.Put(id,entity);
        //}

        //public Customer Login(string customerId, int orderNum)
        //{
        //    return customerService.DeleteCustomer(id);
        //}

        //public List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum)
        //{
        //    return customerService.DeleteCustomer(id);
        //}
    }
}
