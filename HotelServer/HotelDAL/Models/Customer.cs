using System;
using System.Collections.Generic;

namespace HotelDAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            //Messages = new HashSet<Message>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber1 { get; set; } = null!;
        public string? PhoneNumber2 { get; set; }
        public string EmailAddress { get; set; } = null!;

        //public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
