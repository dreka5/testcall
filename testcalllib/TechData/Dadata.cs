using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace testcallLib.TechData
{
    public class Dadata
    {
        public static async Task<object> FindData(QueryInn data)
        {
            var client = new HttpClient();
            var cont = Content(data);
            var url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party"; //ИНН
            foreach (var q in data.query)
            {
                if (!char.IsDigit(q))
                {
                    url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/party";
                    break;
                }
            }
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("token", "74ee82faadc374231c7d7d0aa2f8d5a2c9058982");
            var result = await client.PostAsync(url, cont);
            var byteResult = await result.Content.ReadAsByteArrayAsync();
            return Encoding.UTF8.GetString(byteResult);
        }
        static HttpContent Content(object q)
        {
            string json = JsonConvert.SerializeObject(q);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
