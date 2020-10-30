using Matematik.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MatematikFætteren_3._0.Data
{
    public class Services
    {
        private readonly HttpClient _httpClient;

        public Services(HttpClient client)
        {
            _httpClient = client;

        }

        //News
        //Get
        public async Task<List<News>> GetAllNews()
        {
            var uri = new Uri($"https://localhost:44332/news");

            var responseString = await _httpClient.GetStringAsync(uri);

            List<News> news = JsonConvert.DeserializeObject<List<News>>(responseString);

            return news; 

        }

        //GetFromId
        public async Task<News> GetNewsFromId(int ?id)
        {
            var uri = new Uri($"https://localhost:44332/news/{id}");

            var responseString = await _httpClient.GetStringAsync(uri);

            News news = JsonConvert.DeserializeObject<News>(responseString);

            return news;

        }



        public async Task DeleteNews(int ?id)
        {
            var uri = new Uri($"https://localhost:44332/news/{id}");

            await _httpClient.DeleteAsync(uri);


        }

        public async Task PostNews(News news)
        {

            var uri = new Uri($"https://localhost:44332/news");

            var content = JsonConvert.SerializeObject(news);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(uri, httpContent);


        }

        public async Task PutNews(News news, int ?id)
        {

            var uri = new Uri($"https://localhost:44332/news/{id}");

            var content = JsonConvert.SerializeObject(news);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(uri, httpContent);


        }









    }
}
