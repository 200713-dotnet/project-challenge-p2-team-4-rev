using System.Collections.Generic;

namespace Perspective.Storing
{
    public class UserModel : AModel
    {
        public string Password{get;set;}
        public List<RoomModel> Rooms{get;set;}
        public List<CategoryModel> Catagories{get;set;}
        
    }
}