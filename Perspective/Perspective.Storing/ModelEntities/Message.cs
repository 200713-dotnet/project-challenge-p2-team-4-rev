using System;
using System.Collections.Generic;

namespace Perspective.Storing
{
    public partial class Message
    {
        public Message()
        {
            MessageJunction = new HashSet<MessageJunction>();
        }

        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<MessageJunction> MessageJunction { get; set; }
    }
}
