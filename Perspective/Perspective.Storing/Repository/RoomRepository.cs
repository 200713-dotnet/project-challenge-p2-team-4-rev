using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Perspective.Storing
{
    public class RoomRepository
    {
        MessageRepository MR = new MessageRepository();
        CatagoryRepository CR = new CatagoryRepository();
        public RoomModel Conversion(Room room,PerspectiveDBContext pc)
        {
            RoomModel temp = new RoomModel();
            temp.Topic = room.Topic;
            temp.Name = room.Name;
            temp.Id = room.RoomId;
            temp.DateModified = room.DateModified;
            temp.Messages = MR.GetRoom(pc,temp.Name);
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
        public RoomModel GetWaitList(PerspectiveDBContext pc, string catagoryname)
        {
             Catagory cat = CR.GetCatagory(pc,catagoryname);
             var query = pc.Room.FirstOrDefault(waitlist => waitlist.WaitList == 1);
             return Conversion(query,pc);
        }
    }
}
