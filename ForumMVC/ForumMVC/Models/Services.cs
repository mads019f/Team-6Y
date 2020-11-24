using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Models
{
    public class Services
    {
        private readonly HttpClient _httpClient;

        public Services ( HttpClient httpClient )
        {
            _httpClient = httpClient;
        }

        // Categories
        public async Task<List<Category>> GetCategoriesAsync ( )
        {
            var uri = new Uri($"https://localhost:44346/category");
            var responseString = await _httpClient.GetStringAsync(uri);
            List<Category> items = JsonConvert.DeserializeObject<List<Category>>(responseString);
            return items;
        }

        public async Task<Category> GetCategoryFromIdAsync ( int? id )
        {
            var uri = new Uri($"https://localhost:44346/category/{id}");
            var responseString = await _httpClient.GetStringAsync(uri);
            var item = JsonConvert.DeserializeObject<Category>(responseString);
            return item;
        }

        public async Task DeleteCategoryFromIdAsync ( int? id )
        {
            var uri = new Uri($"https://localhost:44346/category/{id}");
            await _httpClient.DeleteAsync(uri);
        }

        public async Task PostCategoryAsync ( Category category )
        {
            var uri = new Uri("https://localhost:44346/category");
            var content = JsonConvert.SerializeObject(category);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(uri, httpContent);
        }

        public async Task PutCategoryAsync ( int? id, Category category )
        {
            var uri = new Uri($"https://localhost:44346/category/{id}");
            var content = JsonConvert.SerializeObject(category);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(uri, httpContent);
        }

        //Posts
        public async Task PostPostAsync ( Post post )
        {
            var uri = new Uri("https://localhost:44346/post");
            var content = JsonConvert.SerializeObject(post);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(uri, httpContent);
        }
    }
}
