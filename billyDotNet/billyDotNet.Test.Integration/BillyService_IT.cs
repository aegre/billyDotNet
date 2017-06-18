using billyDotNet.Repository;
using billyDotNet.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace billyDotNet.Test.Integration
{
    [TestClass]
    public class BillyService_IT
    {
        private BillyService service;

        [TestInitialize]
        public void SetUp()
        {
            BillyRepository repository = new BillyRepository(new RequesterHelper());
            service = new BillyService(repository);
        }

        [TestMethod]
        public void TestGetBillsByYear()
        {
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";

            int result = service.GetBillsByYear(2017, id);
        }

        [TestMethod]
        public void TestGetBillsByWeek()
        {
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";

            int result = service.GetBillsByWeek(id, 2017, 1, 1, 15);
            Assert.AreEqual(78, result);
        }

        [TestMethod]
        public void TestGetBillsByFortnight()
        {
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";

            int result = service.GetBillsByFortnight(id, 2017, 1, 1);
            Assert.AreEqual(78, result);
        }

        [TestMethod]
        public void TestGetBillsByMonth()
        {
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";

            int result = service.GetBillsByMonth(id, 2017, 1);
            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void TestGetMonthlyBillsByFortnights()
        {
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";

            int result = service.GetMonthlyBillsByFortnights(id, 2017, 1);
            Assert.AreEqual(150, result);
        }

        [TestMethod]
        public void TestGetBillsByDay()
        {
            string id = "3fadd6a2-cee7-4b93-8763-f5402ce70d30";

            int result = service.GetBillsByDay(id, 2017, 1, 1);
            Assert.AreEqual(2, result);
        }
    }
}