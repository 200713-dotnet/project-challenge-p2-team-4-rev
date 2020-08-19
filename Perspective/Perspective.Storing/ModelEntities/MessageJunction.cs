using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class MessageJunction
    {
        public int MessageJunctionId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Message Message { get; set; }
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
