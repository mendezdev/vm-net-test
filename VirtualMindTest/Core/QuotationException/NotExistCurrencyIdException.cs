using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuotationException
{
    public class NotExistCurrencyIdException : Exception
    {
        public NotExistCurrencyIdException() { }

        public NotExistCurrencyIdException(string message) : base(message) { }

        public NotExistCurrencyIdException(string message, Exception inner) : base(message, inner) { }
    }
}
