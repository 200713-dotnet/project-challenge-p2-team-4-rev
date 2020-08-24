using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Perspective.Storing
{
    public static class UserRepository
    {
        public static UserModel Conversion4(PerspectiveDBContext pc,User user)
        {
            UserModel temp = new UserModel();
            temp.Name = user.Name;
            temp.Id = user.UserId;
            temp.DateModified = user.DateModified;
            temp.Password = user.Password;
            temp.Rooms = RoomRepository.GetUser(pc,temp.Name);
            temp.Catagories = CatagoryRepository.GetUser(temp.Name);
            return temp;

        }

        public static UserModel CheckPassword(PerspectiveDBContext pc, string username, string password)
        {
            var query = pc.User.FirstOrDefault(n => n.Name == username && n.Password == password);
            return Conversion4(pc,query);
        }

        public static User GetUser(PerspectiveDBContext pc, string name)
        {
            return pc.User.FirstOrDefault(n => n.Name ==name);
        }
        public static User GetUser(PerspectiveDBContext pc, int id)
        {
            return pc.User.FirstOrDefault(n => n.UserId ==id);
        }
        public static List<UserModel> GetUserData(PerspectiveDBContext pc,string roomname)
        {
            Room room = RoomRepository.GetRoom(pc,roomname);
            List<UserModel> temp = new List<UserModel>();
            List<User> tempusr = new List<User>();
            var tempList = pc.UserRoomJunction.Where(id => id.RoomId == room.RoomId).ToList();
            foreach(var ucj in tempList)
            {
                tempusr.Add(GetUser(pc,ucj.UserId));
            }
            foreach(User u in tempusr)
            {
                UserModel tempModel = new UserModel();
                tempModel = Conversion4(pc,u);
                temp.Add(tempModel);
            }
            return temp;

        }
        public static void Add(PerspectiveDBContext pc, string username,string Password)
        {
            User usr = new User();
            usr.Name = username;
            usr.Password = Password;
            pc.User.Add(usr);
            pc.SaveChanges();
        }
    }
}
