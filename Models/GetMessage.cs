using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Clinic_Automation.Models.Messaging;

namespace Clinic_Automation.Models
{
    public class GetMessage
    {

        public static List<Sender> GetSendersList(string username)
        {
            List<Sender> lst = new List<Sender>();

            using (MedicareEntities1 db = new MedicareEntities1())
            {
                //var getdata = db.ListOfSenders(username);
                var getdata = db.ListOfSenders(username);
                foreach (var item in getdata)
                {                
                    lst.Add(new Sender { SenderId = item.id, username = item.username, seenStatus = item.seenStatus });
                }
            }
            return lst;

        }

        public static int GetLoginID(string username)
        {
            int loginID=0;
            using (MedicareEntities1 db = new MedicareEntities1())
            {
                var getdata = db.Get_LoginID_from_username(username);
                foreach (var item in getdata)
                {
                    loginID = item.Value;
                }
            }

            return loginID;
        }

        public static List<SingleMessage> GetCoversation(int senderId,int receiverId)
        {
            List<SingleMessage> lst = new List<SingleMessage>();

            using (MedicareEntities1 db = new MedicareEntities1())
            {
                var getdata = db.Get_Conversation(senderId,receiverId);
                foreach (var item in getdata)
                {
                    lst.Add(new SingleMessage { SenderId = item.SenderID, MessageContent = item.MessageContent, Timestamp = item.TimeStamp });
                }
            }
            return lst;

        }

    }
}