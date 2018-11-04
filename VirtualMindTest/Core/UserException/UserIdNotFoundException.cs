using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UserException
{
    public class UserIdNotFoundException : Exception
    {
        public UserIdNotFoundException() {}

        public UserIdNotFoundException(string message) : base(message) {}

        public UserIdNotFoundException(string message, Exception inner) : base(message, inner) {}
    }
}
