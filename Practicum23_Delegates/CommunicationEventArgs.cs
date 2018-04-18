using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum23_Delegates_Events
{
    public class CommunicationEventArgs
    {
        public DateTime DateTimeLog { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }

        public CommunicationEventArgs(DateTime date, string sender, string receiver, string message)
        {
            DateTimeLog = date;
            Sender = sender;
            Receiver = receiver;
            Message = message;
        }
    }
}
