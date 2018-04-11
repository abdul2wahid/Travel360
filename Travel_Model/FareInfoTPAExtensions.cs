using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Model
{
    [DataContract]
    public class FareInfoTPAExtensions
    {
        [DataMember(Name = "SeatsRemaining", EmitDefaultValue = false)]
        public SeatsRemaining SeatsRemaining { get; set; }

        [DataMember(Name = "Cabin", EmitDefaultValue = false)]
        public Cabin Cabin { get; set; }

        [DataMember(Name = "Meal", EmitDefaultValue = false)]
        public Meal Meal { get; set; }
    }
}
