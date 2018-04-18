using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum23_Delegates_Strings
{
    public class CommunicationEventArgs
    {
        public DateTime DateTimeLog { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        public CommunicationEventArgs(DateTime date, string sender, string receiver)
        {
            DateTimeLog = date;
            Sender = sender;
            Receiver = receiver;
        }
    }
}
