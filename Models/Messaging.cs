using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Models
{
    public class Messaging
    {
        public int Receiver_Id { get; set; }
        public string Receiver_Name { get; set; }

        public string Selected_Name { get; set; }
        public int Selected_Id { get; set; }

        public string sendMessageContent { get; set; }

        public class Sender
        {
            public int SenderId { get; set; }
            public string username { get; set; }
            public bool seenStatus { get; set; }
        }


        public class SingleMessage
        {
            public int SenderId { get; set; }
            public String MessageContent { get; set; }
            public DateTime Timestamp { get; set; }
        }
        public List<Sender> Sender_List { get; set; }
        public List<SingleMessage> conversation { get; set; }
    }
}