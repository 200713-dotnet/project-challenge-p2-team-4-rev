using System.Collections.Generic;

namespace Perspective.Service.Models
{
  public class RoomModel
    {
        public List<MessageModel> Messages {get;set;}
        public string Topic{get;set;}
    }
}