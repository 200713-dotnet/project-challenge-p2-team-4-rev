﻿using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class Room
    {
        public Room()
        {
            Message = new HashSet<Message>();
            UserRoomJunction = new HashSet<UserRoomJunction>();
        }

        public int RoomId { get; set; }
        public int CatagoryId { get; set; }
        public int WaitList { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Catagory Catagory { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<UserRoomJunction> UserRoomJunction { get; set; }
    }
}
