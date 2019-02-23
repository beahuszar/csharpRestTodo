using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTodo.Utility
{
    public class ResponseMessage
    {
        public string Response { get; set; }

        public ResponseMessage(string response)
        {
            Response = response;
        }
    }
}
