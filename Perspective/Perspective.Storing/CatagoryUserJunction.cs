using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class CatagoryUserJunction
    {
        public int CatagoryUserId { get; set; }
        public int UserId { get; set; }
        public int CatagoryId { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Catagory Catagory { get; set; }
        public virtual User User { get; set; }
    }
}
