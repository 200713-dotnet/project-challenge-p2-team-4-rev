using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class TopicList
    {
        public int TopicListId { get; set; }
        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Catagory Catagory { get; set; }
    }
}
