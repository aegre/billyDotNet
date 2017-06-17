using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using billyDotNet.Utils;
using System.Collections.Generic;

namespace billyDotNet.Test.Unit
{
    [TestClass]
    public class BillyRepository_UT
    {

        private static Mock<IRequesterHelper> requesterHelperMock = new Mock<IRequesterHelper>();


        private static IRequesterHelper requesterHelper = requesterHelperMock.Object;

        [TestMethod]
        public void VerifyGetBillsByDate()
        {
            string expectedResult = "91";

            //Setup the mock to return the expected result
            requesterHelperMock.Setup(requester =>
            requester.MakeGetRequest(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(expectedResult);

            //Get the result
            string result = requesterHelper.MakeGetRequest("", new Dictionary<string, string>());

            Assert.AreEqual(expectedResult, result);

            //Verify method call
            requesterHelperMock.Verify(x => x.MakeGetRequest(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()), Times.Once);

        }
    }
}
