using System.Collections.Generic;

namespace Perpective.Client.Models
{
  public class RoomModel
    {
        public List<MessageModel> Messages {get;set;}
        public string Topic{get;set;}
    }
}