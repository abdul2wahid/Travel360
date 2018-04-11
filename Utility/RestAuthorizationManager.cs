using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Travel_Model;
using System.Web;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Utility
{
    public class RestAuthorizationManager
    {
        /// <summary>
        /// The authorization endpoint address
        /// </summary>
        private const string AuthorizationEndpoint = "/v2/auth/token";

        /// <summary>
        /// The format version (required for call)
        /// </summary>
        private const string FormatVersion = "V1";

       

        /// <summary>
        /// The token holder.
        /// </summary>
        private TokenHolder tokenHolder = TokenHolder.Empty();


        public const string baseuri = "https://api-crt.cert.havail.sabre.com";
        /// <summary>
        /// Initializes a new instance of the <see cref="RestAuthorizationManager"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public RestAuthorizationManager()
        {
           
        }

        /// <summary>
        /// Performs the authorization call asynchronously.
        /// </summary>
        /// <param name="credentials">The credentials string.</param>
        /// <returns>The HTTP response with authorization result model.</returns>
        public async Task<AuthTokenRS> AuthorizeAsync(string credentials)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                var args = new Dictionary<string, string>();
                args.Add("grant_type", "client_credentials");
                var content = new FormUrlEncodedContent(args);
          
             var response =  client.PostAsync(AuthorizationEndpoint, content).Result;



               // HttpResponseMessage response = await client.PostAsync(AuthorizationEndpoint, content);

                return JsonConvert.DeserializeObject<AuthTokenRS>(await response.Content.ReadAsStringAsync());

               

            }
        }

        /// <summary>
        /// Creates the credentials string.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="group">The group.</param>
        /// <param name="secret">The secret.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="formatVersion">The format version.</param>
        /// <returns>The credentials string.</returns>
        public string CreateCredentialsString(string userId, string group, string secret, string domain = "AA", string formatVersion = "V1")
        {
            string clientId = "V1:5gi8qdrkbzp6uzyg:DEVCENTER:EXT"; // string.Format("{0}:{1}:{2}:{3}", formatVersion, userId, group, domain);
            return Base64Encode(Base64Encode(clientId) + ":" + Base64Encode(secret));
        }

        /// <summary>
        /// Gets the authorization token. If token is no longer valid, performs the authorization call asynchronously.
        /// </summary>
        /// <param name="forceRefresh">if set to <c>true</c>, then discard current token and authorize again.</param>
        /// <returns>The token holder.</returns>
        public TokenHolder GetAuthorizationTokenAsync(bool forceRefresh = false)
        {
            if (forceRefresh || this.tokenHolder == null || this.tokenHolder.Token == null || this.tokenHolder.ExpirationDate <= DateTime.Now)
            {
                string userId = "5gi8qdrkbzp6uzyg";
                string group = "DEVCENTER";
                string secret = "pTFx3P7d";
                string domain = "EXT";
                string formatVersion = FormatVersion;
                string clientId = this.CreateCredentialsString(userId, group, secret, domain, formatVersion);
                var response =   AuthorizeAsync(clientId);
            
               this.tokenHolder = TokenHolder.Valid(response.Result.AccessToken, response.Result.ExpiresIn);
               
            }

            return this.tokenHolder;
        }

        /// <summary>
        /// Encodes the string in base64.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>The string in base64.</returns>
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
