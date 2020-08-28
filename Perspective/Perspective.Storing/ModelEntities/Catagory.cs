using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class Catagory
    {
        public Catagory()
        {
            CatagoryUserJunction = new HashSet<CatagoryUserJunction>();
            Room = new HashSet<Room>();
            TopicList = new HashSet<TopicList>();
        }

        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<CatagoryUserJunction> CatagoryUserJunction { get; set; }
        public virtual ICollection<Room> Room { get; set; }
        public virtual ICollection<TopicList> TopicList { get; set; }
    }
}
