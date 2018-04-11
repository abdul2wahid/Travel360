using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Travel_Model
{
    [DataContract]
    public class LowestFare : IObjectOrString
    {
        [DataMember(Name = "AirlineCodes")]
        public IList<string> AirlineCodes { get; set; }

        [DataMember(Name = "Fare")]
        public decimal Fare { get; set; }

        public object WhenString(JToken token)
        {
            return new LowestFare
            {
                AirlineCodes = new List<string>()
            };
        }

        
    }
}
