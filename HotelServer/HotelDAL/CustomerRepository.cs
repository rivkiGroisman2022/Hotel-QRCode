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

        public List<RoomToGuest> GetCustomerAvailability(string customerId, int orderNum)
        {
            throw new NotImplementedException();
        }

        public List<RoomToGuest> GetQRCodes(string customerId, int orderNum)
        {
            try
            {
                List<RoomToGuest> rooms = new List<RoomToGuest>();
                List<Order> orders = context.Orders.Where(x => x.OrderId == orderNum && x.Customer.Id == customerId).ToList();
                foreach (var order in orders)
                {
                    if (DateTime.Now > order.EntryDate && DateTime.Now < order.DepartureDate)
                    {
                        rooms.AddRange(context.RoomToGuests.Where(x => x.OrderId == order.OrderId).ToList());
                    }
                }
                foreach (var room in rooms)
                {
                    room.Order = null;
                }
                return rooms;
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("GetQRCodes", ex.Message);
                return new List<RoomToGuest> { };
            }

        }

        public Customer Login(string customerId, int orederId)
        {
            try
            {
                Customer customer = context.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                if (customer != null)
                {
                    var orders = context.Orders.Where(x => x.OrderId == orederId && x.Customer.Id == customerId && x.EntryDate <= DateTime.Now && x.DepartureDate > DateTime.Now).ToList();
                    if (orders.Count() > 0)
                    {
                        customer.Orders = null;
                        return customer;
                    }
                    else return null;
                }
                else return null;

            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("Login", ex.Message);
                return null;
            }
        }

        public List<RoomToGuest> UpdateAailability(string customerId, int orderNum, int roomNumber, string status)
        {
            try
            {
                List<RoomToGuest> rooms = context.RoomToGuests.Where(x => x.RoomNumber == roomNumber).ToList();
                foreach (var room in rooms)
                {
                    room.Status = status;
                }
                context.SaveChanges();
                return GetQRCodes(customerId, orderNum);
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("UpdateAailability", ex.Message);
                return new List<RoomToGuest>();

            }
        }

        public List<RoomToGuest> UpdateFavoriteRoom(string customerId, int orderNum, int roomNumber, bool favorite)
        {
            try
            {
                List<RoomToGuest> rooms = context.RoomToGuests.Where(x => x.RoomNumber == roomNumber).ToList();
                foreach (var room in rooms)
                {
                    room.Favorite = favorite;
                }
                context.SaveChanges();
                return GetQRCodes(customerId, orderNum);
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("UpdateFavoriteRoom", ex.Message);
                return new List<RoomToGuest>();

            }
        }
    }

}
