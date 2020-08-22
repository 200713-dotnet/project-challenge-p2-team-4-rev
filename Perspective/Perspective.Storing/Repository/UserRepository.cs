using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Perspective.Storing
{
    public class UserRepository
    {
        MessageRepository MR = new MessageRepository();
        CatagoryRepository CR = new CatagoryRepository();
        RoomRepository RR = new RoomRepository();
        public UserModel Conversion(PerspectiveDBContext pc,User user)
        {
            UserModel temp = new UserModel();
            temp.Name = user.Name;
            temp.Id = user.UserId;
            temp.DateModified = user.DateModified;
            temp.Password = user.Password;
            temp.Rooms = RR.GetUser(pc,temp.Name);
            temp.Catagories = CR.GetUser(pc,temp.Name);
            return temp;

        }
        public User GetUser(PerspectiveDBContext pc, string name)
        {
            return pc.User.FirstOrDefault(n => n.Name ==name);
        }
        public User GetUser(PerspectiveDBContext pc, int id)
        {
            return pc.User.FirstOrDefault(n => n.UserId ==id);
        }
        public List<UserModel> GetUserData(PerspectiveDBContext pc,string roomname)
        {
            Room room = RR.GetRoom(pc,roomname);
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
                tempModel = Conversion(pc,u);
                temp.Add(tempModel);
            }
            return temp;

        }
    }
}
