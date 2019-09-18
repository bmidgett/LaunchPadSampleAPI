using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LaunchPadAPI.Infrastructure;
using LaunchPadAPI.Models;

namespace LaunchPadAPI.Services
{
    public class LaunchPadService : ILaunchPadService
    {
        private readonly HttpClient _httpClient;

        public LaunchPadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LaunchPad>> GetLaunchPads(string baseUri, int limit, int offset)
        {
            var uri = URIs.SpaceX.LaunchPad
                .GetLaunchPads(baseUri, limit, offset);

            var response = await _httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            return await response.Content
                    .ReadAsAsync<IEnumerable<LaunchPad>>();
        }
    }
}
