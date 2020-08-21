using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storing
{
    public class CatagoryRepository
    {
        RoomRepository RR = new RoomRepository();
        UserRepository UR = new UserRepository();
        public CategoryModel Conversion(PerspectiveDBContext pc,Catagory cat)
        {
            CategoryModel temp = new CategoryModel();
            temp.Name = cat.Name;
            temp.Description = cat.Description;
            temp.Id = cat.CatagoryId;
            temp.DateModified = cat.DateModified;
            temp.Rooms = RR.GetCategory(pc,temp.Name);
            temp.WaitList = RR.GetWaitList(pc,temp.Name);
            temp.Topics = getTopics(pc,temp.Name);
            return temp;

        }
        public Catagory GetCatagory(PerspectiveDBContext pc,string name)
        {
            return pc.Catagory.FirstOrDefault(n => n.Name ==name);
                
            
        }
        public Catagory GetCatagory(PerspectiveDBContext pc,int id)
        {
            return pc.Catagory.FirstOrDefault(n => n.CatagoryId ==id);
                
            
        }
        public List<string> getTopics(PerspectiveDBContext pc,string name)
        {
            Catagory cat = GetCatagory(pc,name);
            var tempList = new List<string>();
            var query = pc.TopicList.Where(id => id.CatagoryId == cat.CatagoryId);
            foreach( TopicList tl in query){
                tempList.Add(tl.Name);
            }
            return tempList;
        }
        public List<CategoryModel> GetAll(PerspectiveDBContext pc)
        {
            var tempList = new List<CategoryModel>();
            foreach(Catagory c in pc.Catagory)
            {
                tempList.Add(Conversion(pc,c));
            }
            return tempList;
        }
        public List<CategoryModel> GetUser(PerspectiveDBContext pc,string username)
        {
            User usr = UR.GetUser(pc,username);
            List<CategoryModel> temp = new List<CategoryModel>();
            List<Catagory> tempcat = new List<Catagory>();
            var tempList = pc.CatagoryUserJunction.Where(id => id.UserId == usr.UserId).ToList();
            foreach(var ucj in tempList)
            {
                tempcat.Add(GetCatagory(pc,ucj.CatagoryId));
            }
            foreach(Catagory c in tempcat)
            {
                CategoryModel tempModel = new CategoryModel();
                tempModel = Conversion(pc,c);
                temp.Add(tempModel);
            }
            return temp;

        }
    }
}
