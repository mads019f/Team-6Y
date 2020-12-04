using Matematik5_0.Models.WebModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Matematik5_0.Models
{
    public class Service
    {
        private readonly HttpClient _httpClient;

        public Service(HttpClient client)
        {
            _httpClient = client;
        }


        //Tasks

        //Get CategoryExcercise
        public async Task<ExcerciseCategory> GetExcerciseCategoryFromIdAsync(int ?id)
        {
            var uri = new Uri("https://localhost:44356/excercisecategory/{id}");

            var responseString = await _httpClient.GetStringAsync(uri);

            var item = JsonConvert.DeserializeObject<ExcerciseCategory>(responseString);

            return item;

        }

        //Get All Excercise Categories 

        public async Task<List<ExcerciseCategory>> GetExcerciseCategoriesAsync()
        {
            var uri = new Uri("https://localhost:44356/excercisecategory");
            

            var responseString = await _httpClient.GetStringAsync(uri);

            var items = JsonConvert.DeserializeObject<List<ExcerciseCategory>>(responseString);

            return items;

        }

        //Post Category

        public async Task PostExcerciseCategoryAsync(ExcerciseCategory excerciseCategory)
        {
            

            var uri = new Uri("https://localhost:44356/excercisecategory/");

            var content = JsonConvert.SerializeObject(excerciseCategory);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(uri, httpContent);

        }





        //Delete


        //Edit

    }
}
