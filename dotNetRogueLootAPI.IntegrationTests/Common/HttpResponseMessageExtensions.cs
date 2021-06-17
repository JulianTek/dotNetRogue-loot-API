using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.IntegrationTests.Common
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeAsJsonAsync<T>(this HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<T>(body);

            return result;
        }
    }
}
