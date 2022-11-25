using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;

using System.Text;


namespace ApiClient
{
    public class Client : HttpClient, IClient
    {
        public Client() :base()
        {
            BaseAddress = new Uri("https://localhost:44300/");
        }

        public async Task<QueryResult> Get(FilterModel filterModel)
        {
            var data = JsonConvert.SerializeObject(filterModel);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(@"https://localhost:44300/API/features"),
                Content = new StringContent(data, Encoding.UTF8, "application/json"),
            };

            var response = await SendAsync(request).ConfigureAwait(true);

            try
            {
                response.EnsureSuccessStatusCode();
            } catch (Exception e)
            {
                return null;
            }

            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<QueryResult>(content);

            return result;
        }

        public async Task<bool> IsUp()
        {
  
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(@"https://localhost:44300/API/service-status"),
       
            };

            var response = await SendAsync(request).ConfigureAwait(true);
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            if (content == "OK")
            {
                return true;
            }
            return false;
        }
    }
}
