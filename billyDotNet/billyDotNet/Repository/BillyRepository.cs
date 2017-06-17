using billyDotNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Repository
{
    
    /// <summary>
    /// Data repository
    /// </summary>
    public class BillyRepository : IBillyRepository
    {
        private IRequesterHelper requestHelper;
        private readonly string SERVICE_URL = @"http://34.209.24.195/facturas";
        private readonly string DATE_FORMAT = "yyyy-MM-dd";

        /// <summary>
        /// Creates a new instance of billyRepository
        /// </summary>
        /// <param name="requestHelper">Requester helper dependency injection </param>
        public BillyRepository(IRequesterHelper requestHelper)
        {
            this.requestHelper = requestHelper;
        }

        /// <summary>
        /// Returns the service response according to the provided data
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="start">Start date</param>
        /// <param name="finish">Finish date</param>
        /// <returns>The string containing the service response</returns>
        public string GetBillsByDate(string id, DateTime start, DateTime finish)
        {

            //Create the object to be sent 
            Dictionary<string, string> dataObject = new Dictionary<string, string>()
            {
                {"id", id },
                {"start", start.ToString(DATE_FORMAT) },
                {"finish", finish.ToString(DATE_FORMAT) }
            };

            return requestHelper.MakeGetRequest(SERVICE_URL, dataObject);
        }
    }
}
