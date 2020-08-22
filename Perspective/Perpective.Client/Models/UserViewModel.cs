using System;
using System.Collections.Generic;
using Perspective.Storing;

namespace Perpective.Client.Models
{
    public class UserViewModel
    {
        public string Password { get; set; }
        public List<RoomModel> Rooms { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public string Name { get; set; }
    }
}
