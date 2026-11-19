using BundesligaStndings_Backend_.Models;

namespace BundesligaStndings_Backend_.Data.ExternalApi
{

        public class OpenLigaDbClient : IFootballApiClient
        {
            // Bundesliga (bl1), season 2026/27
            private const string TableUrl = "https://api.openligadb.de/getbltable/bl1/2026";

            private readonly HttpClient _http;

            public OpenLigaDbClient(HttpClient http)
            {
                _http = http;
            }

            public async Task<List<Team>> GetTableAsync()
            {
                List<Team>? teams = await _http.GetFromJsonAsync<List<Team>>(TableUrl);
                return teams ?? new List<Team>();
            }
        }
    
}
