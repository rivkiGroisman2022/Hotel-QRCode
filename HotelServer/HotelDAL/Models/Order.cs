using System;
using System.Collections.Generic;

namespace HotelDAL.Models
{
    public partial class Order
    {
        public Order()
        {
            RoomToGuests = new HashSet<RoomToGuest>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int AmountOfRooms { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<RoomToGuest> RoomToGuests { get; set; }
    }
}
