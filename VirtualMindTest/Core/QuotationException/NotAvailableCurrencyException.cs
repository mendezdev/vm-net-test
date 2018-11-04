using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuotationException
{
    public class NotAvailableCurrencyException : Exception
    {
        public NotAvailableCurrencyException() {}

        public NotAvailableCurrencyException(string message) : base(message) {}

        public NotAvailableCurrencyException(string message, Exception inner) : base(message, inner) {}
    }
}
