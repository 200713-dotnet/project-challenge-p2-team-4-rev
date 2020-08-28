using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Perspective.Storing
{
    public static class UserRepository
    {
        public static bool CheckUser(PerspectiveDBContext pc, string username)
        {
            var query = pc.User.FirstOrDefault(n => n.Name == username);
            if(query != null){
                return true;
            }
            else{
            return false;
            }
        }

        public static User GetUser(PerspectiveDBContext pc, string name)
        {
            return pc.User.FirstOrDefault(n => n.Name ==name);
        }
        public static User GetUser(PerspectiveDBContext pc, int id)
        {
            return pc.User.FirstOrDefault(n => n.UserId ==id);
        }
        public static void Add(PerspectiveDBContext pc, string username)
        {
            using(PerspectiveDBContext dbo = new PerspectiveDBContext()){
            User usr = new User();
            usr.Name = username;
            usr.Password = " ";
            dbo.User.Add(usr);
            dbo.SaveChanges();
            }
        }
    }
}
