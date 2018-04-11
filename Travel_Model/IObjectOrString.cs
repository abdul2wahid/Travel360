using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Model
{
    public interface IObjectOrString
    {
        /// <summary>
        /// Create the object instance from string JSON token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>The created object.</returns>
        object WhenString(JToken token);
    }
}
