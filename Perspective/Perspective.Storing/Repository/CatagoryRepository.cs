using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storing
{
    public class CatagoryRepository
    {
        RoomRepository RR = new RoomRepository();
        public CategoryModel Conversion(PerspectiveDBContext pc,Catagory cat)
        {
            CategoryModel temp = new CategoryModel();
            temp.Name = cat.Name;
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
    }
}
