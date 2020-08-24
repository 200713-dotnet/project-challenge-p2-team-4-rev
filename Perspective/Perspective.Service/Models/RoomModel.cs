using System.Collections.Generic;

namespace Perspective.Service.Models
{
  public class RoomModel
  {
    public int ID {get; set;}
    public string Name {get; set;}
    public List<MessageModel> Messages {get; set;}
    public string Topic {get; set;}
  }
}