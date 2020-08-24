using System;
using System.Collections.Generic;
using System.Linq;

namespace Perspective.Storing
{
    public static class CatagoryRepository
    {
        public static CategoryModel Conversion1(Catagory cat)
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {

            
            CategoryModel temp = new CategoryModel();
            temp.Name = cat.Name;
            temp.Description = cat.Description;
            temp.Id = cat.CatagoryId;
            temp.DateModified = cat.DateModified;
            temp.Rooms = RoomRepository.GetCategory(pc,temp.Name);
            temp.WaitList = RoomRepository.GetWaitList(pc,temp.Name);
            temp.Topics = getTopics(temp.Name);
            return temp;
            }

        }
        public static Catagory GetCatagory(PerspectiveDBContext pc,string name)
        {
            using(PerspectiveDBContext db = new PerspectiveDBContext())
            {
            return db.Catagory.FirstOrDefault(n => n.Name ==name);  
            }
        }

        public static void Add(string name, string description)
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {
            Catagory cat = new Catagory();
            cat.DateModified = DateTime.Now;
            cat.Name = name;
            cat.Description = description;
            pc.Catagory.Add(cat);
            pc.SaveChanges();
            }
        }

        public static void AddUser(string UserName,string CatagoryName)
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {
            CatagoryUserJunction temp = new CatagoryUserJunction();
            temp.Catagory = GetCatagory(pc,CatagoryName);
            temp.User = UserRepository.GetUser(pc,UserName);
            pc.CatagoryUserJunction.Add(temp);
            pc.SaveChanges();
            }
        }
    
    //Do some linq queries

        public static Catagory GetCatagory(int id)
        {
            using(PerspectiveDBContext db = new PerspectiveDBContext())
            {
            return db.Catagory.FirstOrDefault(n => n.CatagoryId ==id);  
            }
        }
        public static List<string> getTopics(string name)
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {
            Catagory cat = GetCatagory(pc,name);
            var tempList = new List<string>();
            var query = pc.TopicList.Where(id => id.CatagoryId == cat.CatagoryId);
            foreach( TopicList tl in query){
                tempList.Add(tl.Name);
            }
            return tempList;
            }
        }
        public static List<CategoryModel> GetAll()
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {
            var tempList = new List<CategoryModel>();
            foreach(Catagory c in pc.Catagory)
            {
                tempList.Add(Conversion1(c));
            }
            return tempList;
            }
        }
        public static List<string> GetUser(string username)
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {
            User usr = UserRepository.GetUser(pc,username);
            List<string> temp = new List<string>();
            List<Catagory> tempcat = new List<Catagory>();
            var tempList = pc.CatagoryUserJunction.ToList().Where(id => id.UserId == usr.UserId);
            foreach(var ucj in tempList)
            {
                tempcat.Add(GetCatagory(ucj.CatagoryId));
            }
            foreach(Catagory c in tempcat)
            {
                temp.Add(c.Name);
            }
            return temp;
            }

        }
        public static string GetTopic(string CatagoryName)
        {
            using(PerspectiveDBContext pc = new PerspectiveDBContext())
            {
            Catagory cat = GetCatagory(pc,CatagoryName);
            var query = pc.TopicList.Where(id => id.CatagoryId == cat.CatagoryId).ToArray();
            Random Rand = new Random();
            var result = query[Rand.Next(query.Length-1)];
            return result.Name;
            }


        }
    }
}
