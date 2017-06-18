using billyDotNet.Repository;
using billyDotNet.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace billyDotNet.Test.Unit
{
    [TestClass]
    public class BillyRepository_UT
    {
        private IRequesterHelper requesterHelper;

        private Mock<IRequesterHelper> requesterHelperMock;

        private BillyRepository repository;

        [TestInitialize]
        public void Setup()
        {
            requesterHelperMock = new Mock<IRequesterHelper>();
            requesterHelper = requesterHelperMock.Object;

            repository = new BillyRepository(requesterHelper);
        }

        [TestMethod]
        public void VerifyGetBillsByDate()
        {
            string expectedResult = "91";

            //Setup the mock to return the expected result
            requesterHelperMock.Setup(requester =>
            requester.MakeGetRequest(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(expectedResult);

            //Get the result
            string result = repository.GetBillsByDate("", DateTime.Now, DateTime.Now);

            Assert.AreEqual(expectedResult, result);

            //Verify method call
            requesterHelperMock.Verify(x => x.MakeGetRequest(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
        }
    }
}