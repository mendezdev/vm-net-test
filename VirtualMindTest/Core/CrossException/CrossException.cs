using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossException
{
    public class CrossException : Exception
    {
        public CrossException() { }

        public CrossException(string message) : base(message) { }
    }
}
