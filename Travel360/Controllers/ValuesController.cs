using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Travel_Model;
using Utility;

namespace Travel360.Controllers
{
    public class ValuesController : ApiController
    {
       
        public ValuesController()
        {
           
        }

        [HttpGet]
        [Route("GetFlightFares")]
        public async Task<FlightFares> GetFlightFares(FindFlightsFare s)
        {
            
            string queryString = RequestContext.Url.Request.RequestUri.Query;
            string decoded = HttpUtility.UrlDecode(queryString);
            decoded = decoded.Substring(3);

            FindFlightsFare result = JsonConvert.DeserializeObject<FindFlightsFare>(decoded);




            string path = "/v2/shop/flights/fares?origin=" + result.origin + "&destination=" + result.destination + "&lengthofstay=" + result.lengthofstay + "&departuredate=" + result.departuredate + "&minfare=" + result.minfare + "&maxfare=" + result.maxfare  + "&pointofsalecountry=" + result.pointofsalecountry;
            

            FlightFares flightFares = null;
            using (RestClient restClient = new RestClient())
            {
                flightFares = await restClient.GetFlightFaresAsync(path);
            }
            return flightFares;
        }

        [HttpGet]
        [Route("GetFlightFare")]
        public string GetFlightFare()
        {
            return "wahid";
        }



        
        public string Post(string value)
        {
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
