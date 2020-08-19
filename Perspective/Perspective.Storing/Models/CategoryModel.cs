using System.Collections.Generic;

namespace Perspective.Storing
{
    public class CategoryModel: AModel
    {
        string Description{get;set;}
        List<RoomModel> Rooms {get;set;}
        List<UserModel> WaitList {get;set;}
        List<string> Topics{get;set;}
        
    }
}