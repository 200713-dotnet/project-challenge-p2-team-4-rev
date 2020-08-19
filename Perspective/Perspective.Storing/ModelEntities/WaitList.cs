using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class WaitList
    {
        public int WaitListId { get; set; }
        public int RoomId { get; set; }
        public int CatagoryId { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Catagory Catagory { get; set; }
        public virtual Room Room { get; set; }
    }
}
