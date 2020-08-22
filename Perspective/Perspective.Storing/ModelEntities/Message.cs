using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
