using System;
using System.Collections.Generic;

namespace HotelDAL.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public string MessageContent { get; set; } = null!;
        public string RequestOrResponse { get; set; } = null!;
        public DateTime MessageDatetime { get; set; }
        public bool MessageAnswered { get; set; }
        public int ResponseTo { get; set; }

        public virtual Customer User { get; set; } = null!;
    }
}
