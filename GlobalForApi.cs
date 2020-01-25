using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace OnlineVoting
{
    public static class GlobalForApi
    {
        public static HttpClient CandidatesApiClient = new HttpClient();

        static GlobalForApi()
        {
            CandidatesApiClient.BaseAddress = new Uri("https://localhost:44321/api/");
            CandidatesApiClient.DefaultRequestHeaders.Clear();
            CandidatesApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }

    }
}