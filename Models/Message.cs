//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinic_Automation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string MessageContent { get; set; }
        public bool SeenStatus { get; set; }
    
        public virtual Message Messages1 { get; set; }
        public virtual Message Message1 { get; set; }
    }
}