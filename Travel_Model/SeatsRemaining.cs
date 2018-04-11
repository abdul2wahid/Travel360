using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Model
{
    [DataContract]
    public class SeatsRemaining
    {
        [DataMember(Name = "Number")]
        public int Number { get; set; }

        [DataMember(Name = "BelowMin")]
        public bool BelowMin { get; set; }
    }
}
