using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class Room
    {
        public Room()
        {
            CatagoryRoomJunction = new HashSet<CatagoryRoomJunction>();
            MessageJunction = new HashSet<MessageJunction>();
            WaitList = new HashSet<WaitList>();
        }

        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<CatagoryRoomJunction> CatagoryRoomJunction { get; set; }
        public virtual ICollection<MessageJunction> MessageJunction { get; set; }
        public virtual ICollection<WaitList> WaitList { get; set; }
    }
}
