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
            temp.Messages = MessageRepository.GetRoom(pc,room.RoomId);
            return temp;

        }
        

        public static void AddUser(PerspectiveDBContext pc, string UserName,string RoomName)
        {
            UserRoomJunction temp = new UserRoomJunction();
            temp.Room = GetRoom(pc,RoomName);
            var tempUser = UserRepository.GetUser(pc,UserName);
            if(tempUser != null){
            temp.User = tempUser;
            pc.UserRoomJunction.Add(temp);
            pc.SaveChanges();
            }
            else{
            UserRepository.Add(pc,UserName);
            tempUser = UserRepository.GetUser(pc,UserName);
            pc.UserRoomJunction.Add(temp);
            pc.SaveChanges();
            }
            
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
    }
}
