using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAppicationBlazor.Services
{
    public class TaskApiClient : ITaskApiClient
    {
        private readonly HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IA getAll()
        {
            var result = _httpClient.GetFromJsonAsync("/category/");
        }
    }
}
