using System.Collections.Generic;

namespace Perspective.Service.Models
{
  public class CategoryModel
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RoomModel> Rooms {get; set;}
    public List<UserModel> WaitList {get; set;}
    public List<string> Topics {get; set;}

  }
}