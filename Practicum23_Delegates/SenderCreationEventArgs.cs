using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum23_Delegates_Strings
{
    public class SenderCreationEventArgs
    {
        public string SenderId { get; set; }

        public SenderCreationEventArgs(string id)
        {
            SenderId = id;
        }
    }
}
