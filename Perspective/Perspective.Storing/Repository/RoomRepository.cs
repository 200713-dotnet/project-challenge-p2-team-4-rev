using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Perspective.Storing
{
    public static class RoomRepository
    {

        public static RoomModel Conversion3(Room room,PerspectiveDBContext pc)
        {
            RoomModel temp = new RoomModel();
            temp.Topic = room.Topic;
            temp.Name = room.Name;
            temp.Id = room.RoomId;
            temp.DateModified = room.DateModified;
            temp.Messages = MessageRepository.GetRoom(pc,temp.Name);
            temp.Users = UserRepository.GetUserData(pc,temp.Name);
            return temp;

        }
        
        public static List<RoomModel> GetCategory(PerspectiveDBContext pc,string catagoryname)
        {
            Catagory cat = CatagoryRepository.GetCatagory(pc,catagoryname);
            List<RoomModel> temp = new List<RoomModel>();
            var tempList = pc.Room.Where(id => id.CatagoryId == cat.CatagoryId).ToList();
            foreach(Room r in tempList)
            {
                RoomModel tempModel = new RoomModel();
                tempModel = Conversion3(r,pc);
                temp.Add(tempModel);
            }
            return temp;

        }
        public static List<string> GetUser(PerspectiveDBContext pc,string username)
        {
            User usr = UserRepository.GetUser(pc,username);
            List<string> temp = new List<string>();
            List<Room> temproom = new List<Room>();
            var tempList = pc.UserRoomJunction.Where(id => id.UserId == usr.UserId).ToList();
            foreach(var urj in temproom)
            {
                temproom.Add(GetRoom(pc,urj.RoomId));
            }
            foreach(Room r in temproom)
            {
                RoomModel tempModel = new RoomModel();
                tempModel = Conversion3(r,pc);
                temp.Add(tempModel.Name);
            }
            return temp;

        }

        public static void AddUser(PerspectiveDBContext pc, string UserName,string RoomName)
        {
            UserRoomJunction temp = new UserRoomJunction();
            temp.Room = GetRoom(pc,RoomName);
            temp.User = UserRepository.GetUser(pc,UserName);
            pc.UserRoomJunction.Add(temp);
            pc.SaveChanges();
        }

        public static RoomModel GetWaitList(PerspectiveDBContext pc, string catagoryname)
        {
             Catagory cat = CatagoryRepository.GetCatagory(pc,catagoryname);
             var query = pc.Room.FirstOrDefault(waitlist => waitlist.WaitList == 1);
             return Conversion3(query,pc);
        }
        public static Room GetRoom(PerspectiveDBContext pc,int id)
        {
            return pc.Room.FirstOrDefault(i => i.RoomId == id);
        }
        public static Room GetRoom(PerspectiveDBContext pc,string name)
        {
            return pc.Room.FirstOrDefault(i => i.Name == name);
        }
        public static List<MessageModel> GetMessages(PerspectiveDBContext pc, string roomname)
        {
             Room rm = GetRoom(pc,roomname);
             var query = pc.Message.Where(id => id.RoomId == rm.RoomId).ToList();
             var tempList = new List<MessageModel>();
             foreach(var m in query){
             tempList.Add(MessageRepository.Conversion2(pc,m.Name));
             }
             return tempList;
        }
        public static void add(PerspectiveDBContext pc,string roomName,string userName, string content)
        {
            Message msg = new Message();
            msg.Room = GetRoom(pc,roomName);
            msg.User = UserRepository.GetUser(pc,userName);
            msg.Content = content;
            pc.Message.Add(msg);
        }
    }
}
