using System;

namespace Perpective.Client.Models
{
    public class RoomViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string textName{get;set;}
        public string message{get;set;}
    }
}