using System.Collections.Generic;

namespace Perspective.Storing
{
    public class RoomModel : AModel
    {
        public List<MessageModel> Messages {get;set;}
        public string Topic{get;set;}
    }
}