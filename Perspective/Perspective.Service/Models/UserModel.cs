using System.Collections.Generic;

namespace Perspective.Service.Models
{
  public class UserModel
  {
    public int ID {get; set;}
    public string Name {get; set;}
    private string Password {get; set;}
    List<RoomModel> Rooms {get; set;}
    List<CategoryModel> Categories {get; set;}

  }
}