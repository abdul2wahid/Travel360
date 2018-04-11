using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Model
{
    [DataContract]
    public class Cabin
    {
        [DataMember(Name = "Cabin")]
        public string CabinCode { get; set; }
    }
}
