using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class User
    {
        public User()
        {
            CatagoryUserJunction = new HashSet<CatagoryUserJunction>();
            Message = new HashSet<Message>();
            UserRoomJunction = new HashSet<UserRoomJunction>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<CatagoryUserJunction> CatagoryUserJunction { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<UserRoomJunction> UserRoomJunction { get; set; }
    }
}
