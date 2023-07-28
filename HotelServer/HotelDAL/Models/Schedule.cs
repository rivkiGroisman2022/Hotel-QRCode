using System;
using System.Collections.Generic;

namespace HotelDAL.Models
{
    public partial class Schedule
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; } = null!;
    }
}
