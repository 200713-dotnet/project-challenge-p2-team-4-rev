using System;
using System.Collections.Generic;
using Perspective.Storing;

namespace Perpective.Client.Models
{
    public class CategoryViewModel
    {
        public string Description{get;set;}
        public List<RoomModel> Rooms {get;set;}
        public RoomModel WaitList {get;set;}
        public List<string> Topics{get;set;}
    }
}