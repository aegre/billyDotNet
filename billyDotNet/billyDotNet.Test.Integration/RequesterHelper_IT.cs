using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using billyDotNet.Utils;
using System.Collections.Generic;

namespace billyDotNet.Test.Integration
{
    [TestClass]
    public class RequesterHelper_IT
    {
        [TestMethod]
        public void TestGetResponse()
        {
            RequesterHelper requesterHelper = new RequesterHelper();

            Dictionary<string, string> dataObject = new Dictionary<string, string>()
            {
                { "id", "3fadd6a2-cee7-4b93-8763-f5402ce70d30" },
                { "start", "2017-01-01" },
                { "finish", "2017-01-17" }
            };
            string destinationURL = @"http://34.209.24.195/facturas";

            string actual = requesterHelper.MakeGetRequest(destinationURL, dataObject);

            string expectedResult = "91";

            Assert.AreEqual(expectedResult, actual);

        }
    }
}
