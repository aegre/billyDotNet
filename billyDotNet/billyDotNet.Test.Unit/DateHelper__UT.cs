using billyDotNet.Model;
using billyDotNet.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Test.Unit
{
    [TestClass]
    public class DateHelper__UT
    {
        [TestMethod]
        public void TestGetWeeksInAMonth()
        {

            //The month ends in monday (extra week)
            int expectedWeeks = 6;
            List<Week> weeks = DateHelper.GetWeeksInAMonth(2017, 7, 1, 31);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //Normal month
            expectedWeeks = 5;
            weeks = DateHelper.GetWeeksInAMonth(2017, 6, 1, 30);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //Month starts in sunday
            expectedWeeks = 6;
            weeks = DateHelper.GetWeeksInAMonth(2017, 1, 1, 31);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //4 weeks month
            expectedWeeks = 4;
            weeks = DateHelper.GetWeeksInAMonth(2010, 2, 1, 28);
            Assert.AreEqual(expectedWeeks, weeks.Count);

        }

        [TestMethod]
        public void TestGetSecondFornightWeeksInAMonth()
        {

            //The month ends in monday (extra week)
            int expectedWeeks = 4;
            List<Week> weeks = DateHelper.GetWeeksInAMonth(2017, 7, 16, 31);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //Normal month
            expectedWeeks = 3;
            weeks = DateHelper.GetWeeksInAMonth(2017, 6, 16, 30);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //Month ends in sunday
            expectedWeeks = 3;
            weeks = DateHelper.GetWeeksInAMonth(2017, 1, 16,31);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //4 weeks month
            expectedWeeks = 2;
            weeks = DateHelper.GetWeeksInAMonth(2010, 2, 16, 28);
            Assert.AreEqual(expectedWeeks, weeks.Count);

        }

        [TestMethod]
        public void TestGetFirstFornightWeeksInAMonth()
        {

            //The month ends in monday (extra week)
            int expectedWeeks = 3;
            List<Week> weeks = DateHelper.GetWeeksInAMonth(2017, 7, 1, 15);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //Normal month
            expectedWeeks = 3;
            weeks = DateHelper.GetWeeksInAMonth(2017, 6, 1, 15);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //Month ends in sunday
            expectedWeeks = 3;
            weeks = DateHelper.GetWeeksInAMonth(2017, 1, 1, 15);
            Assert.AreEqual(expectedWeeks, weeks.Count);

            //4 weeks month
            expectedWeeks = 3;
            weeks = DateHelper.GetWeeksInAMonth(2010, 2, 1, 15);
            Assert.AreEqual(expectedWeeks, weeks.Count);

        }

        [TestMethod]
        public void TestExceptionInGetWeeksInAMonth()
        {
            Exception messageException = Assert.ThrowsException<Exception>(() => DateHelper.GetWeeksInAMonth(2017,1,15,1));
            Assert.AreEqual(messageException.Message, "The initial day must be fewer thant the end day");
        }

    }
}
