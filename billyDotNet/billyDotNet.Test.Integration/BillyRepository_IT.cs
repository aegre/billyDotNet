using billyDotNet.Repository;
using billyDotNet.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Test.Integration
{
    [TestClass]
    public class BillyRepository_IT
    {
        [TestMethod]
        public void TestGetBillsByDate()
        {
            RequesterHelper requesterHelper = new RequesterHelper();
            BillyRepository billyRepository = new BillyRepository(requesterHelper);


            //Data object
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";
            DateTime start = new DateTime(2017, 1, 1);
            DateTime finish = new DateTime(2017, 1, 17);


            //Get the result
            string actual = billyRepository.GetBillsByDate(id, start, finish);

            string expectedResult = "91";

            Assert.AreEqual(expectedResult, actual);

        }
    }
}
