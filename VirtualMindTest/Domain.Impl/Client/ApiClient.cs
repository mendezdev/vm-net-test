using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Impl.Client
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient client;

        public ApiClient(HttpClient client)
        {
            this.client = client;
        }

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return client.GetAsync(uri);
        }
    }
}
