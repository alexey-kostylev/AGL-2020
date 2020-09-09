using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Agl.Api.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Agl.Api.Services.Implementation
{
    public class DataService : IDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AglSettings> _options;

        public DataService(IHttpClientFactory httpClientFactory, IOptions<AglSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            var url = _options.Value?.PeopleEndpointUrl;

            if (string.IsNullOrEmpty(url))
            {
                throw new InvalidOperationException($"{nameof(_options.Value.PeopleEndpointUrl)} is null");
            }

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException($"Error getting data from endpoint: {_options.Value.PeopleEndpointUrl}: Reason={response.ReasonPhrase}");
                }
                var body = await response.Content.ReadAsStringAsync();
                var people = JsonConvert.DeserializeObject<ICollection<Person>>(body);
                return people;
            }
        }
    }
}
