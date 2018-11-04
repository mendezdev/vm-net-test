using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class Response<T>
    {
        public T ObjectResponse { get; set; }
        public bool HasError { get; set; }
        public int CodeError { get; set; }
        public string Message { get; set; }
    }
}
