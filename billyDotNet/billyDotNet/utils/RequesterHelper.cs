using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Utils
{
    public class RequesterHelper : IRequesterHelper
    {

        

        /// <summary>
        /// Makes a get request with the provided variables
        /// </summary>
        /// <param name="destinationURL">The destination URL.</param>
        /// <param name="getVariables">Variables to be sent as get variables</param>
        /// <returns></returns>
        public string MakeGetRequest(string destinationURL, Dictionary<string, string> getVariables)
        {
            //Build the query string parameters
            string UriParameter = BuildQueryString(getVariables);


            string completeUri = UriParameter.Length > 0 ? $"{destinationURL}{UriParameter}" : destinationURL;
            var httpWebRequest = WebRequest.Create(completeUri);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result = string.Empty;

            //Read the response
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            
            //Return the fetched string 

            return result;
        }


        /// <summary>
        /// Creates an string containing all the variables as a get string
        /// </summary>
        /// <param name="variables">Variables to be converted</param>
        /// <returns>
        /// String containing the variables in get form
        /// </returns>
        private static string BuildQueryString(Dictionary<string, string> variables)
        {
            string queryString = string.Empty;

            //If we have no variable we return an empty string
            if (variables != null && variables.Count > 0)
            {
                //Read every key in the dicctionary, the gets its value
                foreach (string key in variables.Keys)
                {
                    if (!string.IsNullOrEmpty(variables[key]))
                    {
                        string variableName = Uri.EscapeUriString(key);
                        string variableValue = Uri.EscapeUriString(variables[key]);
                        //Create an uri parameter "key=value&"
                        queryString = $"{queryString}{variableName}={variableValue}&";
                    }
                }

                //Clean the last "&" characther and add "?" at the begining
                if (queryString.Length > 0)
                {
                    queryString = queryString.Substring(0, queryString.Length - 1);
                    queryString = $"?{queryString}";
                }
            }

            return queryString;
        }
    }
}
