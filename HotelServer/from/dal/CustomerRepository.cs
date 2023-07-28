using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly HotelContext context;
        public CustomerRepository(HotelContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                context.Customers.Remove(context.Customers.Find(id));//search specific customer like - getById
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return context.Customers.Find(id);
        }

        public bool Post(Customer entity)
        {
            try
            {
                context.Customers.Add(entity);  
                return true;
            }
            catch (Exception)
            {
                return false;
            }     
        }

        public Customer Put(int id, Customer entity)
        {
            try
            {
                context.Customers.Remove(context.Customers.Find(id));
                context.Customers.Add(entity); 
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
