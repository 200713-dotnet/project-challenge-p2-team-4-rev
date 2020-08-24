using System.Collections.Generic;

namespace Perspective.Storing
{
    public class CategoryModel: AModel
    {
        public string Description{get;set;}
        public List<RoomModel> Rooms {get;set;}
        public int WaitList {get;set;}
        public List<string> Topics{get;set;}
        
    }
}