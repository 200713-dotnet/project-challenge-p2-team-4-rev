using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storing
{
    public class MessageRepository
    {
        public MessageModel Conversion(Message msg)
        {
            MessageModel temp = new MessageModel();
            temp.content = msg.Content;
            temp.Name = msg.Name;
            temp.Id = msg.MessageId;
            temp.DateModified = msg.DateModified;
            return temp;

        }
        public List<MessageModel> GetRoom(PerspectiveDBContext pc,string roomname)
        {
            List<MessageModel> temp = new List<MessageModel>();
            foreach(Message m in pc.Message.ToList().Where(name => name.Name == roomname))
            {
                MessageModel tempModel = new MessageModel();
                tempModel = Conversion(m);
                temp.Add(tempModel);
            }
            return temp;

        }
    }
}
