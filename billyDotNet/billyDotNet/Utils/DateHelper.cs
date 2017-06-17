using billyDotNet.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billyDotNet.Utils
{
    public class DateHelper
    {
        /// <summary>
        /// Get the weeks in a month between the initial day and the en day
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="initialDay">The initial day</param>
        /// <param name="endDay">The end day</param>
        /// <returns>weeks in a month between the initial day and the en day</returns>
        public static List<Week> GetWeeksInAMonth(int year, int month, int initialDay, int endDay)
        {

            if(initialDay > endDay)
            {
                throw new Exception("The initial day must be fewer thant the end day");
            }

            //Get all the weekends (sundays)
            List<DateTime> weekendsInTheMonth = GetWeekendsInTheMonth(year, month, initialDay, endDay);

            List<Week> weeks = new List<Week>();
            
            int current = initialDay;
            int lastAddedDay = 0;

            weekendsInTheMonth.ForEach(weekend =>
            {

                //Add a week starting in the current day to the first weekend
                DateTime start = new DateTime(year, month, current);
                weeks.Add(new Week()
                {
                    Start = start,
                    End = weekend
                });

                //Update last added
                lastAddedDay = weekend.Day;
                //Update current
                current = weekend.AddDays(1).Day;
            });
            
            //If the end day has not been added, add the extra week
            if(lastAddedDay != endDay)
            {
                DateTime start = new DateTime(year, month, current);
                DateTime end = new DateTime(year, month, endDay);
                weeks.Add(new Week()
                {
                    Start = start,
                    End = end
                });
            }
            return weeks;
        }


        /// <summary>
        /// Get the wekends in the provided period
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="initialDay">The initial day</param>
        /// <param name="endDay">The end day</param>
        /// <returns></returns>
        private static List<DateTime> GetWeekendsInTheMonth(int year, int month, int initialDay, int endDay)
        {
            //First get all the dates in the month
            List<DateTime> datesInTheMonth = new List<DateTime>( Enumerable.Range(1, DateTime.DaysInMonth(year, month)).
                Select(n => new DateTime(year, month, n)));

            //Leave only the sundays after the initial day and before the end day
            datesInTheMonth = (from day in datesInTheMonth
                               where day.DayOfWeek == DayOfWeek.Sunday && day.Day >= initialDay && day.Day <= endDay
                               select day).ToList();

            return datesInTheMonth;
        }
    }
}
