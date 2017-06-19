using billyDotNet.Model;
using billyDotNet.Repository;
using billyDotNet.Utils;
using System;
using System.Collections.Generic;

namespace billyDotNet
{
    public class BillyService
    {
        private IBillyRepository billyRepository;
        public int RequestCount { get; set; }

        /// <summary>
        /// Creates a new instance of the billy service
        /// </summary>
        /// <param name="billyRepository">billy repository dependency injection</param>
        public BillyService(IBillyRepository billyRepository)
        {
            this.billyRepository = billyRepository;
        }

        /// <summary>
        /// Get the total count of bills by year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="id">Id to search</param>
        /// <returns>The count of bills</returns>
        public int GetBillsByYear(int year, string id)
        {
            //Create datetimes with the range of dates for the year
            DateTime start = new DateTime(year, 1, 1);
            DateTime finish = new DateTime(year, 12, 1);

            //If the start date is after the finish date thow an exception
            if (start > finish)
            {
                throw new Exception("The end date must be greater than the start date.");
            }

            int result = 0;

            //loop all the months in the year, we can exclude all those months that are in a future date
            while (start <= finish)// && start < DateTime.Now)
            {
                int bills = GetBillsByMonth(id, start.Year, start.Month);
                result += bills;

                start = start.AddMonths(1);
            }

            return result;
        }

        /// <summary>
        /// Get the total bill of a provided month
        /// </summary>
        /// <param name="id">The id </param>
        /// <param name="year">The year</param>
        /// <param name="month">The mont</param>
        /// <returns>Count of bills in the month</returns>
        public int GetBillsByMonth(string id, int year, int month)
        {
            //Generate datetimes with the range according to the month
            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);

            //make a first try sending the whole month
            string serviceResponse = billyRepository.GetBillsByDate(id, start, end);
            RequestCount++;
            int bills = 0;

            //Check if is a number what we fetched
            if (!int.TryParse(serviceResponse, out bills))
            {
                //If it is not a number we now try fetching the data by fortnights
                bills = GetMonthlyBillsByFortnights(id, year, month);
            }

            return bills;
        }

        /// <summary>
        /// Get the monthly bills count by requesting the data by fortnights
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <returns>Monthly bills count </returns>
        public int GetMonthlyBillsByFortnights(string id, int year, int month)
        {
            //Create the range of dates for the first fortnight
            DateTime start = new DateTime(year, month, 1);
            DateTime end = new DateTime(year, month, 15);

            int bills = 0;

            //GetTheBills for the firsth fortnight
            bills = GetBillsByFortnight(id, year, month, 1);
            //Then the second
            bills += GetBillsByFortnight(id, year, month, 2);

            return bills;
        }

        /// <summary>
        /// Get the bills requesting the data by fortnight
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="fornight">The number of fornight</param>
        /// <returns>The bills according to the provided fortnight</returns>
        public int GetBillsByFortnight(string id, int year, int month, int fornight)
        {
            //Depending on the fornight we create the dates
            DateTime start = fornight == 1 ? new DateTime(year, month, 1) : new DateTime(year, month, 16);
            DateTime end = fornight == 1 ? new DateTime(year, month, 15) : new DateTime(year, month, 1).AddMonths(1).AddDays(-1);

            int bills = 0;

            string serviceResponse = billyRepository.GetBillsByDate(id, start, end);
            RequestCount++;
            if (!int.TryParse(serviceResponse, out bills))
            {
                //If the service response is not a number now we will try requesting the data by weeks
                bills = GetBillsByWeek(id, year, month, start.Day, end.Day);
            }

            return bills;
        }

        /// <summary>
        /// Get the bills by requesting the data weekly in a range of days
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="startDay">The start day</param>
        /// <param name="endDay">The end day</param>
        /// <returns></returns>

        public int GetBillsByWeek(string id, int year, int month, int startDay, int endDay)
        {
            //Get a list of weeks according to the provided days
            List<Week> weeks = DateHelper.GetWeeksInAMonth(year, month, startDay, endDay);

            int bills = 0;

            weeks.ForEach(week =>
            {
                //Foreach week, fetch the data
                string serviceResponse = billyRepository.GetBillsByDate(id, week.Start, week.End);
                int weeklyBills = 0;
                RequestCount++;
                if (int.TryParse(serviceResponse, out weeklyBills))
                {
                    //if the fetched data is a number, add it to the bills
                    bills += weeklyBills;
                }
                else
                {
                    //if not now we have to make the requests by day :(
                    while (week.Start <= week.End)
                    {
                        bills += GetBillsByDay(id, year, month, week.Start.Day);
                        week.Start = week.Start.AddDays(1);
                    }
                }
            }

            );
            return bills;
        }

        /// <summary>
        /// Get the bills in a day
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <returns>Count of bills in a day</returns>
        public int GetBillsByDay(string id, int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);

            //We send the same date,
            string serviceResponse = billyRepository.GetBillsByDate(id, date, date);
            RequestCount++;
            int bills = 0;
            if (!int.TryParse(serviceResponse, out bills))
            {
                //If the response is not a number give up x_x
                throw new Exception("The provided id contains too much bills :(");
            }
            return bills;
        }
    }
}