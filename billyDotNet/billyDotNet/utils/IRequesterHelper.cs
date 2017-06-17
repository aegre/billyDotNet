using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.utils
{
    /// <summary>
    /// Helper interface for requesters
    /// </summary>
    public interface IRequesterHelper
    {
        /// <summary>
        /// Makes the get request.
        /// </summary>
        /// <param name="destinationURL">The destination URL.</param>
        /// <param name="getVariables">The get variables.</param>
        /// <returns>The result returned by the server</returns>
        string MakeGetRequest(string destinationURL, Dictionary<string, string> getVariables);

    }
}
