using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum23_Delegates_Events
{
    public class MessageEventArgs
    {
        public string Message { get; set; }
        public string Receiver { get; set; }

        public MessageEventArgs(string message , string receiver)
        {
            Message = message;
            Receiver = receiver;
        }
    }
}
