using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Travel_Model;

namespace Utility
{
    public class RestClient:IDisposable
    {
        public static readonly HttpClient hTTPClient = new HttpClient();
      
        static RestAuthorizationManager restAuthorizationManager = null;

        static RestClient()
        {
            restAuthorizationManager = new RestAuthorizationManager();
            hTTPClient.BaseAddress = new Uri(RestAuthorizationManager.baseuri);
            hTTPClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", restAuthorizationManager.GetAuthorizationTokenAsync(false).Token);
            hTTPClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        }

       

        public  async Task<FlightFares> GetFlightFaresAsync(string path)
        {

            FlightFares fares = null; 
            
           HttpResponseMessage response = await hTTPClient.GetAsync(path );
            if (response.IsSuccessStatusCode)
            {

                fares = await response.Content.ReadAsAsync<FlightFares>();
            }
            return fares;
        }

        public void Dispose()
        {

        }
    }
}
