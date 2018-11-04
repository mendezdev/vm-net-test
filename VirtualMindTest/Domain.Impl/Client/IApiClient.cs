using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Impl.Client
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
    }
}
