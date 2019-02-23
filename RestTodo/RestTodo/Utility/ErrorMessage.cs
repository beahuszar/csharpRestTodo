using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTodo.Utility
{
    public class ErrorMessage
    {
        public string Error { get; }

        public ErrorMessage(string error)
        {
            this.Error = error;
        }
    }
}
