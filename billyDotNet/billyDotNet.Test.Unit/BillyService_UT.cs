using billyDotNet.Repository;
using billyDotNet.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Test.Unit
{
    [TestClass]
    public class BillyService_UT
    {
        private IBillyRepository repository;

        private  Mock<IBillyRepository> repositoryMock = new Mock<IBillyRepository>();

        private BillyService service;

        [TestInitialize]
        public void Setup()
        {
            repositoryMock = new Mock<IBillyRepository>();
            repository = repositoryMock.Object;

            service = new BillyService(repository);
        }

        [TestMethod]
        public void VerifyGetBillsByDay()
        {
            string expectedResult = "91";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Assert.AreEqual(91, service.GetBillsByDay("", 2017, 1, 1));

            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);

        }

        [TestMethod]
        public void VerifyGetBillsByDayFail()
        {
            string expectedResult = "Mas de 100 resultados";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Exception e = Assert.ThrowsException<Exception>(() => service.GetBillsByDay("", 2017, 1, 1));

            Assert.AreEqual("The provided id contains too much bills :(", e.Message);

            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public void VerifyGetBillsByFortnight()
        {
            string expectedResult = "91";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Assert.AreEqual(91, service.GetBillsByFortnight("", 2017, 1, 1));


            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);

        }

        [TestMethod]
        public void VerifyGetBillsByFortnightFail()
        {
            string expectedResult = "Mas de 100 resultados";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Exception e = Assert.ThrowsException<Exception>(() => service.GetBillsByFortnight("", 2017, 1, 1));

            Assert.AreEqual("The provided id contains too much bills :(", e.Message);

            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(3));

        }

        [TestMethod]
        public void VerifyGetBillsByMonth()
        {
            string expectedResult = "91";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Assert.AreEqual(91, service.GetBillsByMonth("", 2017, 1));


            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public void VerifyGetBillsByMonthFail()
        {
            string expectedResult = "Mas de 100 resultados";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Exception e = Assert.ThrowsException<Exception>(() => service.GetBillsByMonth("", 2017, 1));

            Assert.AreEqual("The provided id contains too much bills :(", e.Message);

            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(4));

        }

        [TestMethod]
        public void VerifyGetBillsByWeek()
        {
            string expectedResult = "91";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Assert.AreEqual(91 * 3, service.GetBillsByWeek("",2017,1,1,15));


            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(3));
        }

        [TestMethod]
        public void VerifyGetBillsByWeekFail()
        {
            string expectedResult = "Mas de 100 resultados";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Exception e = Assert.ThrowsException<Exception>(() => service.GetBillsByWeek("", 2017, 1, 1, 15));

            Assert.AreEqual("The provided id contains too much bills :(", e.Message);
            
            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(2));
        }

        [TestMethod]
        public void VerifyGetBillsByYear()
        {
            string expectedResult = "91";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Assert.AreEqual(91 * 12, service.GetBillsByYear(2017, ""));


            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(12));
        }

        [TestMethod]
        public void VerifyGetBillsByYearFail()
        {
            string expectedResult = "Mas de 100 resultados";

            repositoryMock.Setup(repository =>
            repository.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(expectedResult);

            Exception e = Assert.ThrowsException<Exception>(() => service.GetBillsByYear(2017, ""));

            Assert.AreEqual("The provided id contains too much bills :(", e.Message);

            //Verify method call
            repositoryMock.Verify(x => x.GetBillsByDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(4));
        }

    }
}
