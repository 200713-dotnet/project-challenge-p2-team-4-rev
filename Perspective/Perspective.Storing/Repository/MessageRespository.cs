using System;
using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storing
{
    public static class MessageRepository
    {
        public static MessageModel Conversion2(PerspectiveDBContext pc, int messageId)
        {
            Message msg = GetMessage(pc,messageId);
            MessageModel temp = new MessageModel();
            temp.Content = msg.Content;
            temp.UserName = msg.Name;
            return temp;

        }

        private static Message GetMessage(PerspectiveDBContext pc,int Id)
        {
            return pc.Message.FirstOrDefault(i => i.MessageId == Id);
        }

        public static List<MessageModel> GetRoom(PerspectiveDBContext pc,int roomid)
        {
            List<MessageModel> temp = new List<MessageModel>();
            foreach(Message m in pc.Message.ToList().Where(id => id.RoomId == roomid))
            {
                MessageModel tempModel = new MessageModel();
                tempModel = Conversion2(pc,m.MessageId);
                temp.Add(tempModel);
            }
            return temp;

        }
        public static void Add(PerspectiveDBContext pc, string RoomName,string UserName,string content)
        {
            Room room = RoomRepository.GetRoom(pc,RoomName);
            Message msg = new Message();
            msg.Room = room;
            msg.Content = content;
            msg.Name = UserName;
            msg.User = UserRepository.GetUser(pc,UserName);
            pc.Message.Add(msg);
            pc.SaveChanges();
            
            
        }
    }
}
