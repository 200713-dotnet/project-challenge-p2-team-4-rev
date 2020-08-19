using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class Catagory
    {
        public Catagory()
        {
            CatagoryRoomJunction = new HashSet<CatagoryRoomJunction>();
            CatagoryUserJunction = new HashSet<CatagoryUserJunction>();
            TopicList = new HashSet<TopicList>();
            WaitList = new HashSet<WaitList>();
        }

        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<CatagoryRoomJunction> CatagoryRoomJunction { get; set; }
        public virtual ICollection<CatagoryUserJunction> CatagoryUserJunction { get; set; }
        public virtual ICollection<TopicList> TopicList { get; set; }
        public virtual ICollection<WaitList> WaitList { get; set; }
    }
}
