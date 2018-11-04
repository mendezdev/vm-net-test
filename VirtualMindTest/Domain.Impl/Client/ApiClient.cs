using Core.CrossException;
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

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new CrossException("Ocurrió un problema al intentar obtener la cotización. Intente de nuevo mas tarde, por favor.");
            }

            return await response.Content.ReadAsAsync<T>();
        }
    }
}
