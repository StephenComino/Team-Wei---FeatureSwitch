using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class Client : HttpClient, IClient
    {
        public Client() :base()
        {
            BaseAddress = new Uri("https://localhost:44300/");
            DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<QueryResult> Get(FilterModel filterModel)
        {
            var data = JsonConvert.SerializeObject(filterModel);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(@"https://localhost:44300/API/features"),
                Content = new StringContent(data, Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = await SendAsync(request).ConfigureAwait(true);
            response.EnsureSuccessStatusCode();

            
            return new QueryResult();
        }
    }
}
