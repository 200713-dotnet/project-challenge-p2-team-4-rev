using System.Collections.Generic;

namespace Perspective.Storing
{
    public class UserModel : AModel
    {
        public string Password{get;set;}
        List<RoomModel> Rooms{get;set;}
        List<CategoryModel> Catagories{get;set;}
        
    }
}