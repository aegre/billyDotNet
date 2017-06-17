using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Repository
{
    //Data repository interface
    public interface IBillyRepository
    {
        /// <summary>
        /// Returns the service response according to the provided data
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="start">Start date</param>
        /// <param name="finish">Finish date</param>
        /// <returns>The string containing the service response</returns>
        string GetBillsByDate(string id, DateTime start, DateTime finish);
    }
}
