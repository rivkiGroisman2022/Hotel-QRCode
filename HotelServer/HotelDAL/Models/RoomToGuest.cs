using System;
using System.Collections.Generic;

namespace HotelDAL.Models
{
    public partial class RoomToGuest
    {
        public int RoomToGuestId { get; set; }
        public int OrderId { get; set; }
        public int RoomNumber { get; set; }
        public string Qr { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Status { get; set; } = null!;
        public bool Favorite { get; set; } = false!;

        public virtual Order Order { get; set; } = null!;
    }
}
