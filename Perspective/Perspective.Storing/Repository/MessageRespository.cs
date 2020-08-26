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
            temp.Content = msg.Content;
            temp.UserName = msg.Name;
            return temp;

        }
        public static List<MessageModel> GetRoom(PerspectiveDBContext pc,int roomid)
        {
            List<MessageModel> temp = new List<MessageModel>();
            foreach(Message m in pc.Message.ToList().Where(id => id.RoomId == roomid))
            {
                MessageModel tempModel = new MessageModel();
                tempModel = Conversion2(pc,m.Name);
                temp.Add(tempModel);
            }
            return temp;

        }
        public static void Add(PerspectiveDBContext pc, string UserName,string RoomName,string content)
        {
            Room room = RoomRepository.GetRoom(pc,RoomName);
            Message msg = new Message();
            msg.Room = room;
            msg.Content = content;
            msg.Name = UserName;
            msg.User = UserRepository.GetUser(pc,UserName);
            
            pc.SaveChanges();
            
            
        }
    }
}
