using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Model
{
    [DataContract]
    public class FlightFares
    {
        [DataMember(Name = "OriginLocation")]
        public string OriginLocation { get; set; }

        [DataMember(Name = "DestinationLocation")]
        public string DestinationLocation { get; set; }

        [DataMember(Name = "FareInfo")]
        public IList<FareInfos> FareInfo { get; set; }

        [DataMember(Name = "Links")]
        public IList<Link> Links { get; set; }
    }
}
