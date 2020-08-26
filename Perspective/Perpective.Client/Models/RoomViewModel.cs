using System;
using System.Collections.Generic;
using Perspective.Storing;

namespace Perpective.Client.Models
{
    public class RoomViewModel
    {
        public List<MessageModel> Messages {get;set;}
        public List<UserModel> Users {get;set;}
        public string Topic{get;set;}
    }
}