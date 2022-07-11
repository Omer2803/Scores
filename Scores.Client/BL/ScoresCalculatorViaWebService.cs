using Newtonsoft.Json;
using Scores.Client.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Scores.Client.BL
{
    class ScoresCalculatorViaWebService : IScoresCalculator
    {
        private static HttpClient client = new HttpClient();
        private const string URL = "https://localhost:44341/";
        private const string ACTION = "/api/Scores/GetCalculatedScores";

        public Dictionary<string, int> GetCalculatedScores()
        {
            return GetCalculateScoresAsync().Result;
        }

        private async Task<Dictionary<string, int>> GetCalculateScoresAsync()
        {
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ACTION);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Dictionary<string, int>>(result);
            }
            return null;
        }
    }
}
