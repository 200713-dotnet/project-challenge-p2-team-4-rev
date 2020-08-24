using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storing
{
    public static class MessageRepository
    {
        public static MessageModel Conversion2(PerspectiveDBContext pc, string messagename)
        {
            Message msg = new Message();
            MessageModel temp = new MessageModel();
            temp.content = msg.Content;
            temp.Name = msg.Name;
            temp.Id = msg.MessageId;
            temp.DateModified = msg.DateModified;
            return temp;

        }
        public static List<MessageModel> GetRoom(PerspectiveDBContext pc,string roomname)
        {
            List<MessageModel> temp = new List<MessageModel>();
            foreach(Message m in pc.Message.ToList().Where(name => name.Name == roomname))
            {
                MessageModel tempModel = new MessageModel();
                tempModel = Conversion2(pc,m.Name);
                temp.Add(tempModel);
            }
            return temp;

        }
    }
}
