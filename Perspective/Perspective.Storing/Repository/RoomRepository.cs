using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Perspective.Storing
{
    public class RoomRepository
    {
        MessageRepository MR = new MessageRepository();
        CatagoryRepository CR = new CatagoryRepository();
        UserRepository UR = new UserRepository();
        public RoomModel Conversion(Room room,PerspectiveDBContext pc)
        {
            RoomModel temp = new RoomModel();
            temp.Topic = room.Topic;
            temp.Name = room.Name;
            temp.Id = room.RoomId;
            temp.DateModified = room.DateModified;
            temp.Messages = MR.GetRoom(pc,temp.Name);
            temp.Users = UR.GetUserData(pc,temp.Name);
            return temp;

        }
        
        public List<RoomModel> GetCategory(PerspectiveDBContext pc,string catagoryname)
        {
            Catagory cat = CR.GetCatagory(pc,catagoryname);
            List<RoomModel> temp = new List<RoomModel>();
            var tempList = pc.Room.Where(id => id.CatagoryId == cat.CatagoryId).ToList();
            foreach(Room r in tempList)
            {
                RoomModel tempModel = new RoomModel();
                tempModel = Conversion(r,pc);
                temp.Add(tempModel);
            }
            return temp;

        }
        public List<RoomModel> GetUser(PerspectiveDBContext pc,string username)
        {
            User usr = UR.GetUser(pc,username);
            List<RoomModel> temp = new List<RoomModel>();
            List<Room> temproom = new List<Room>();
            var tempList = pc.UserRoomJunction.Where(id => id.UserId == usr.UserId).ToList();
            foreach(var urj in temproom)
            {
                temproom.Add(GetRoom(pc,urj.RoomId));
            }
            foreach(Room r in temproom)
            {
                RoomModel tempModel = new RoomModel();
                tempModel = Conversion(r,pc);
                temp.Add(tempModel);
            }
            return temp;

        }
        public RoomModel GetWaitList(PerspectiveDBContext pc, string catagoryname)
        {
             Catagory cat = CR.GetCatagory(pc,catagoryname);
             var query = pc.Room.FirstOrDefault(waitlist => waitlist.WaitList == 1);
             return Conversion(query,pc);
        }
        public Room GetRoom(PerspectiveDBContext pc,int id)
        {
            return pc.Room.FirstOrDefault(i => i.RoomId == id);
        }
        public Room GetRoom(PerspectiveDBContext pc,string name)
        {
            return pc.Room.FirstOrDefault(i => i.Name == name);
        }
        public List<MessageModel> GetMessages(PerspectiveDBContext pc, string roomname)
        {
             Room rm = GetRoom(pc,roomname);
             var query = pc.Message.Where(id => id.RoomId == rm.RoomId).ToList();
             var tempList = new List<MessageModel>();
             foreach(var m in query){
             tempList.Add(MR.Conversion(pc,m.Name));
             }
             return tempList;
        }
        public void add(PerspectiveDBContext pc,string roomName,string userName, string content)
        {
            Message msg = new Message();
            msg.Room = GetRoom(pc,roomName);
            msg.User = UR.GetUser(pc,userName);
            msg.Content = content;
            pc.Message.Add(msg);
        }
    }
}
